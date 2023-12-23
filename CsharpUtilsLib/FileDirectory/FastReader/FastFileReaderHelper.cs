namespace CsharpUtilsLib.FileDirectory.FastReader;

public abstract class FastFileReaderHelper : IDisposable
{
    protected string _inputFile;
    protected List<string> _headers;
    protected List<string> _skipHeaders;
    protected int _totalOfHeaders;
    protected string _delimiter;
    protected string _newLine;
    protected byte _delimiterByte;
    protected byte _newLineByte;
    protected Pipe _pipe = new Pipe(new PipeOptions(null, null, null, 4096, 2048, 1024, true));
    protected Encoding _encoding = Encoding.UTF8;
    protected int _batchSize = 150000;
    protected bool _skipFirstRow = false;

    public FastFileReaderHelper(string inputFile, List<string> headers, string delimiter, List<string> skipHeaders = null!, string newLine = "\n")
    {
        _delimiter = delimiter;
        _newLine = newLine;
        _inputFile = inputFile;
        _headers = headers;
        _skipHeaders = (skipHeaders ?? new List<string>());

        SetEncodingVariables();
    }

    public virtual void SetGlobalConfigs(Encoding? encoding = null!, int? batchSize = null!, bool? skipFirstRow = null!)
    {
        _encoding = encoding ?? _encoding;
        _batchSize = batchSize ?? _batchSize;
        _skipFirstRow = skipFirstRow ?? _skipFirstRow;
        SetEncodingVariables();
    }

    public virtual void StartProcess()
    {
        Task readingTask = ReadFile(_pipe.Writer);
        Task processingTask = ProcessFile(_pipe.Reader);
        Task.WhenAll(readingTask, processingTask).Wait();
    }

    protected byte GetFirstByteFromText(string text)
    {
        return _encoding.GetBytes(text)[0];
    }

    protected void SetEncodingVariables()
    {
        _delimiterByte = GetFirstByteFromText(_delimiter);
        _newLineByte = GetFirstByteFromText(_newLine);
    }

    protected async Task ReadFile(PipeWriter writer)
    {
        //Reads the file in chunks and writes those chunks to a PipeWriter,
        //which is an efficient way to pass data between different parts of code,
        //especially in asynchronous operations.

        try
        {
            using (FileStream file = File.Open(_inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                while (true)
                {
                    Memory<byte> memory = writer.GetMemory();
                    int count = file.Read(memory.Span);

                    if (count == 0)
                    {
                        break;
                    }

                    writer.Advance(count);
                    FlushResult result = await writer.FlushAsync();

                    if (result.IsCompleted)
                    {
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while reading the file: {_inputFile}. {ex.Message}");
        }
        finally
        {
            await writer.CompleteAsync();
        }
    }

    protected virtual async Task ProcessFile(PipeReader reader)
    {
        try
        {
            await ProcessAndWriteInBatches(reader);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during file processing: {_inputFile}. {ex.Message}");
        }
        finally
        {
            BuildBatchRows();
            await reader.CompleteAsync();
        }
    }

    protected virtual async Task ProcessAndWriteInBatches(PipeReader reader)
    {
        //After reading data from a PipeReader line by line,
        //it processes these lines in batches, ensuring that all data from
        //the PipeReader is processed and written to the output
        //file before finishing reading.
        long totalOfRecords = 0;

        while (true)
        {
            ReadResult readResult = await reader.ReadAsync();
            ReadOnlySequence<byte> buffer = readResult.Buffer;
            SequencePosition? endOfLinePos = buffer.PositionOf(_newLineByte);

            while (endOfLinePos.HasValue)
            {
                totalOfRecords += ProcessLine(buffer.Slice(0, endOfLinePos.Value));
                buffer = buffer.Slice(buffer.GetPosition(1, endOfLinePos.Value));
                endOfLinePos = buffer.PositionOf(_newLineByte);

                if (_skipFirstRow)
                {
                    RemoveFirstRow();
                }

                if (totalOfRecords % _batchSize == 0)
                {
                    BuildBatchRows();
                    Console.WriteLine($"Total of records processed: {totalOfRecords}...");
                }
            }

            reader.AdvanceTo(buffer.Start, buffer.End);

            if (readResult.IsCompleted)
            {
                break;
            }
        }

        Console.WriteLine($"Total of records processed: {totalOfRecords}.");
    }

    protected virtual int ProcessLine(ReadOnlySequence<byte> data)
    {
        // Process the data in a single segment       
        if (data.IsSingleSegment)
        {
            return ProcessLineSingleSegment(data.First.Span);
        }

        return ProcessSharedPool(data);
    }

    protected virtual int ProcessSharedPool(ReadOnlySequence<byte> data)
    {
        byte[] rentedStorage = null!;

        try
        {
            // If the data is divided into multiple segments, the method allocates a
            // byte array in shared memory, copies the data to that array,
            // and then calls the function to process the data from that array.
            // After processing, the array is returned to shared memory.
            rentedStorage = ArrayPool<byte>.Shared.Rent((int)data.Length);
            data.CopyTo(rentedStorage);
            int total = ProcessLineSingleSegment(rentedStorage.AsSpan(0, (int)data.Length));
            return total;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error when trying to process a shared pool. Input File: {_inputFile}. {ex.Message}");
            return 0;
        }
        finally
        {
            if (rentedStorage != null)
            {
                ArrayPool<byte>.Shared.Return(rentedStorage);
            }
        }
    }

    protected virtual int TotalOfOccurrences(ref ReadOnlySpan<byte> span)
    {
        int delimiterCount = 0;

        foreach (int index in Enumerable.Range(0, span.Length))
        {
            if (span[index] == _delimiterByte)
            {
                delimiterCount++;
            }
        }

        return delimiterCount;
    }

    protected virtual int ProcessLineSingleSegment(ReadOnlySpan<byte> span)
    {
        ClearSpanRowSequence(ref span);
        int totalOfOccurrences = TotalOfOccurrences(ref span);

        if ((totalOfOccurrences + 1) != _headers.Count)
        {
            return 0;
        }

        int delimiterPosition = span.IndexOf(_delimiterByte);

        foreach (int index in Enumerable.Range(0, _headers.Count))
        {
            if (_skipHeaders.Contains(_headers[index]))
            {
                continue;
            }

            string rowValue = ExtractCurrentRow(ref span, ref delimiterPosition, index != 0);
            InsertRowValueInYourCollection(rowValue, index);
        }

        return 1;
    }

    protected virtual string ExtractCurrentRow(ref ReadOnlySpan<byte> span, ref int delimiterPosition, bool skipPreviousPosition = true)
    {
        if (skipPreviousPosition)
        {
            span = span.Slice(delimiterPosition + 1);
        }

        delimiterPosition = span.IndexOf(_delimiterByte);

        return _encoding.GetString(delimiterPosition <= -1 ? span : span.Slice(0, delimiterPosition));
    }

    protected virtual void RemoveFirstRow()
    {
        _skipFirstRow = false;
    }

    protected abstract void ClearSpanRowSequence(ref ReadOnlySpan<byte> span);

    protected abstract void InsertRowValueInYourCollection(string rowValue, int index);

    protected abstract void BuildBatchRows();

    public abstract void Dispose();
}