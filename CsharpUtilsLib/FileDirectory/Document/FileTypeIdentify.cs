namespace CsharpUtilsLib.FileDirectory.Document;

/// <summary>
/// Helper class to identify file type by the file header, not file extension.
/// For more information on the implementation File Signatures:
/// http://www.garykessler.net/library/file_sigs.html
/// https://en.m.wikipedia.org/wiki/List_of_file_signatures
/// https://filesignatures.net/index.php?page=all&order=DESCRIPTION&sort=DESC&alpha=R
/// For more information mime types:
/// https://docs.microsoft.com/en-us/previous-versions/office/office-2007-resource-kit/ee309278(v=office.12)?redirectedfrom=MSDN
/// TODO: Determine specific type of based ZIP files
/// </summary>
public static class FileTypeIdentify
{
    // all the file types to be put into one list
    public static readonly List<FileType> FileTypes = FileTypeHelper.AllAvailableFormats();

    // number of bytes we read from a file
    public const int MaxHeaderSize = 560;  // some file formats have headers offset to 512 bytes

    #region Main Methods

    /// <summary>
    /// Read header of a file and depending on the information in the header
    /// return object FileType.
    /// Return null in case when the file type is not identified.
    /// Throws Application exception if the file can not be read or does not exist
    /// </summary>
    /// <param name="fileHeaderReadFunc">A function which returns the bytes found</param>
    /// <returns>FileType or null not identified</returns>
    public static FileType GetFileType(Func<byte[]> fileHeaderReadFunc)
    {
        // if none of the types match, return null
        FileType fileType = null!;

        // read first n-bytes from the file
        byte[] fileHeader = fileHeaderReadFunc();

        if (fileHeader == null)
        {
            return null!;
        }

        // Sanity Check (if it's binary shouldn't work with UTF-16 OR UTF-32 files)
        if (!fileHeader.Any(bynary => bynary == 0))
        {
            //Verify specific type of text file
            fileType = CheckSpecificTxtFileType(fileHeader);
        }
        else
        {
            // compare the file header to the stored file headers
            foreach (FileType currentFileType in FileTypes)
            {
                int matchingCount = GetFileMatchingCount(fileHeader, currentFileType);

                //Check if count bytes is equals and is different zero
                if (matchingCount == currentFileType.Header.Length && matchingCount != 0)
                {
                    fileType = currentFileType;    // if all the bytes match, return the type
                    break;
                }
            }
        }
        return fileType!;
    }

    private static FileType CheckSpecificTxtFileType(byte[] fileHeader)
    {
        //Extract txt and check your type
        string extractedText = Encoding.UTF8.GetString(fileHeader);

        //Check HTML
        if (FilesDirectories.IsHTML(extractedText))
        {
            return FileTypeHelper.HTML;
        }
        //Check JSON
        else if (FilesDirectories.IsJson(extractedText))
        {
            return FileTypeHelper.JSON;
        }
        //Check XML
        else if (FilesDirectories.IsXML(fileHeader))
        {
            return FileTypeHelper.XML;
        }
        //Default
        else
        {
            return FileTypeHelper.TXT;
        }
    }

    private static int GetFileMatchingCount(byte[] fileHeader, FileType type)
    {
        int matchingCount = 0;
        try
        {
            foreach (int index in Enumerable.Range(0, type.Header.Length))
            {
                // if file offest is greater than header file, ignore it.
                // if file offset is not set to zero, we need to take this into account when comparing.
                // if byte in type.header is set to null, means this byte is variable, ignore it.
                if (fileHeader.Length < type.HeaderOffset ||
                    type.Header[index] != null &&
                     type.Header[index] != fileHeader[index + type.HeaderOffset])
                {
                    // if one of the bytes does not match, move on to the next type
                    matchingCount = 0;
                    break;
                }
                else
                {
                    matchingCount++;
                }
            }
        }
        catch
        {
            matchingCount = 0;
        }
        return matchingCount;
    }

    #endregion Main Methods
}