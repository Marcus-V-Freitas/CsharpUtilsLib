using Column = ParquetSharp.Column;

namespace CsharpUtilsLib.FileDirectory.FastReader;

public sealed class ParquetBuildReaderHelper : FastFileReaderHelper
{
    private readonly ParquetFileWriter _parquetWriter;
    private Dictionary<string, List<string>> _columnsToExport;
    private IEnumerable<byte[]> _sequencesOfCharactersToRemove;

    public ParquetBuildReaderHelper(string outputFile, string inputFile, List<string> headers, string delimiter, List<string> skipHeaders = null!, List<string> sequencesOfCharactersToRemove = null!, string newLine = "\n") : base(inputFile, headers, delimiter, skipHeaders, newLine)
    {
        _parquetWriter = new ParquetFileWriter(outputFile, DefineColumnsSchema());
        _columnsToExport = InitializeTempDict();
        SetSequencesOfCharactersToRemove(TransformCharactersToRemoveInBytes(sequencesOfCharactersToRemove));
    }

    private IEnumerable<byte[]> TransformCharactersToRemoveInBytes(List<string> sequencesOfCharactersToRemove)
    {
        if (sequencesOfCharactersToRemove.ListIsNullOrEmpty())
        {
            return null!;
        }

        return sequencesOfCharactersToRemove.Select(c => _encoding.GetBytes(c));
    }

    private void SetSequencesOfCharactersToRemove(IEnumerable<byte[]> sequencesOfCharactersToRemove)
    {
        _sequencesOfCharactersToRemove = sequencesOfCharactersToRemove;
    }

    private Dictionary<string, List<string>> InitializeTempDict()
    {
        Dictionary<string, List<string>> columnsToExport = new Dictionary<string, List<string>>();

        foreach (string headerToExport in _headers)
        {
            if (_skipHeaders.Contains(headerToExport))
            {
                continue;
            }

            columnsToExport.Add(headerToExport, new List<string>());
        }

        return columnsToExport;
    }

    private Column[] DefineColumnsSchema()
    {
        List<Column> columnToExport = new List<Column>();

        foreach (string fieldName in _headers)
        {
            if (_skipHeaders.Contains(fieldName))
            {
                continue;
            }

            columnToExport.Add(new Column<string>(fieldName));
        }

        return columnToExport.ToArray();
    }

    private void ClearDictRows()
    {
        foreach (KeyValuePair<string, List<string>> columnToExport in _columnsToExport)
        {
            columnToExport.Value.Clear();
        }
    }

    private int IndexOfSequence(ReadOnlySpan<byte> span, int startIndex, byte[] sequeceOfCharacters)
    {
        for (int i = startIndex; i <= span.Length - sequeceOfCharacters.Length; i++)
        {
            bool found = true;
            for (int j = 0; j < sequeceOfCharacters.Length; j++)
            {
                if (span[i + j] != sequeceOfCharacters[j])
                {
                    found = false;
                    break;
                }
            }

            if (found)
            {
                return i;
            }
        }

        return -1;
    }

    protected override void BuildBatchRows()
    {
        using (RowGroupWriter rowGroup = _parquetWriter.AppendRowGroup())
        {
            foreach (string headerToExport in _headers)
            {
                if (_skipHeaders.Contains(headerToExport))
                {
                    continue;
                }

                using (LogicalColumnWriter<string> logicalColumnWriter = rowGroup.NextColumn().LogicalWriter<string>())
                {
                    logicalColumnWriter.WriteBatch(_columnsToExport[headerToExport].ToArray());
                }
            }
        }

        ClearDictRows();
    }

    protected override void InsertRowValueInYourCollection(string rowValue, int index)
    {
        _columnsToExport[_headers[index]].Add(rowValue);
    }

    private void RemoveWrongCharactersFromSpan(ref ReadOnlySpan<byte> span, byte[] sequeceOfCharacters)
    {
        if (span.IndexOf(sequeceOfCharacters) == -1)
        {
            return;
        }

        int index = -1;

        while ((index = IndexOfSequence(span, index + 1, sequeceOfCharacters)) != -1)
        {
            ReadOnlySpan<byte> beforeSpan = span.Slice(0, index);
            ReadOnlySpan<byte> afterSpan = span.Slice(index + sequeceOfCharacters.Length);

            // Combine the two spans into a single contiguous span (excluding the byte at indexToRemove).
            Span<byte> result = new byte[beforeSpan.Length + afterSpan.Length];
            beforeSpan.CopyTo(result);
            afterSpan.CopyTo(result.Slice(beforeSpan.Length));
            span = result;
        }
    }

    protected override void ClearSpanRowSequence(ref ReadOnlySpan<byte> span)
    {
        if (_sequencesOfCharactersToRemove == null)
        {
            return;
        }

        foreach (byte[] sequeceOfCharacters in _sequencesOfCharactersToRemove)
        {
            RemoveWrongCharactersFromSpan(ref span, sequeceOfCharacters);
        }
    }

    public override void SetGlobalConfigs(Encoding? encoding = null!, int? batchSize = null!, bool? skipFirstRow = null!)
    {
        base.SetGlobalConfigs(encoding, batchSize, skipFirstRow);
        SetSequencesOfCharactersToRemove(_sequencesOfCharactersToRemove);
    }

    protected override void RemoveFirstRow()
    {
        base.RemoveFirstRow();
        ClearDictRows();
    }

    public override void Dispose()
    {
        _parquetWriter.Dispose();
    }
}
