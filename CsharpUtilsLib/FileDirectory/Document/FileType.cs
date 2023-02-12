namespace CsharpUtilsLib.FileDirectory.Document;

/// <summary>
/// Little data structure to hold information about file types.
/// Holds information about binary header at the start of the file
/// </summary>
public sealed class FileType
{
    /// <summary>
    /// File Signature (bytes)
    /// </summary>
    public byte?[] Header { get; set; }

    /// <summary>
    /// Number of bytes offsetted to confirm their type
    /// </summary>
    public int HeaderOffset { get; set; }

    /// <summary>
    /// File extension (without dot)
    /// </summary>
    public string Extension { get; set; }

    /// <summary>
    /// Media type (two-part identifier for file formats and format contents transmitted on the Internet)
    /// </summary>
    public string Mime { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileType"/> class.
    /// Default construction with the header offset being set to zero by default
    /// </summary>
    /// <param name="header">Byte array with header.</param>
    /// <param name="extension">String with extension.</param>
    /// <param name="mime">The description of MIME.</param>
    public FileType(byte?[] header, string extension, string mime)
    {
        Header = header;
        Extension = extension;
        Mime = mime;
        HeaderOffset = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileType"/> struct.
    /// Takes the details of offset for the header
    /// </summary>
    /// <param name="header">Byte array with header.</param>
    /// <param name="offset">The header offset - how far into the file we need to read the header</param>
    /// <param name="extension">String with extension.</param>
    /// <param name="mime">The description of MIME.</param>
    public FileType(byte?[] header, int offset, string extension, string mime)
    {
        Header = null!;
        Header = header;
        HeaderOffset = offset;
        Extension = extension;
        Mime = mime;
    }

    public override bool Equals(object other)
    {
        if (!(other is FileType))
        {
            return false;
        }

        FileType otherType = (FileType)other;

        if (Extension == otherType.Extension && Mime == otherType.Mime) return true;

        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return Extension;
    }
}