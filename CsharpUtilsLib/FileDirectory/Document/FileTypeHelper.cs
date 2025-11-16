namespace CsharpUtilsLib.FileDirectory.Document;

public readonly struct FileTypeHelper
{
    // office and common documents

    #region office and common documents like xml, pdf and rtf

    // office and documents
    public static readonly FileType DOC = new([0xEC, 0xA5, 0xC1, 0x00], 512, "doc", "application/msword");

    public static readonly FileType XLS = new([0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00], 512, "xls", "application/excel");
    public static readonly FileType PPT = new([0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1], "ppt", "application/mspowerpoint");

    //ms office and openoffice docs (they're zip files: rename and enjoy!)
    //don't add them to the list, as they will be 'subtypes' of the ZIP type
    public static readonly FileType PPTX = new([], 512, "pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");

    public static readonly FileType DOCX = new([], 512, "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
    public static readonly FileType XLSX = new([], 512, "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    public static readonly FileType ODT = new([], 512, "odt", "application/vnd.oasis.opendocument.text");
    public static readonly FileType ODS = new([], 512, "ods", "application/vnd.oasis.opendocument.spreadsheet");
    public static readonly FileType ODP = new([], 512, "odp", "application/vnd.oasis.opendocument.presentation-template");

    // common documents
    public static readonly FileType RTF = new([0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31], "rtf", "application/rtf");

    public static readonly FileType PDF = new([0x25, 0x50, 0x44, 0x46], "pdf", "application/pdf");
    public static readonly FileType XML = new([0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x22, 0x31, 0x2E, 0x30, 0x22, 0x3F, 0x3E], "xml", "text/xml");

    //text files
    public static readonly FileType TXT = new([], "txt", "text/plain");

    public static readonly FileType TXT_UTF8 = new([0xEF, 0xBB, 0xBF], "txt", "text/plain");
    public static readonly FileType TXT_UTF16_BE = new([0xFE, 0xFF], "txt", "text/plain");
    public static readonly FileType TXT_UTF16_LE = new([0xFF, 0xFE], "txt", "text/plain");
    public static readonly FileType TXT_UTF32_BE = new([0x00, 0x00, 0xFE, 0xFF], "txt", "text/plain");
    public static readonly FileType TXTUTF32LE = new([0xFF, 0xFE, 0x00, 0x00], "txt", "text/plain");

    #endregion office and common documents like xml, pdf and rtf

    // Images Files

    #region jpeg, png, ico

    public static readonly FileType JPEG = new([0xFF, 0xD8, 0xFF], "jpg", "image/jpeg");
    public static readonly FileType PNG = new([0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A], "png", "image/png");
    public static readonly FileType ICO = new([0, 0, 1, 0], "ico", "image/x-icon");

    #endregion jpeg, png, ico

    // Compressed files

    #region Zip, 7zip, rar, tar, bz2, gz, tgz

    public static readonly FileType GZ = new([0x1F, 0x8B, 0x08 ], "gz", "application/x-gz");
    public static readonly FileType TGZ = new([0x1F, 0x8B, 0x08], "tgz", "application/x-gz");
    public static readonly FileType ZIP_7z = new([ 66, 77 ], "7z", "application/x-compressed");
    public static readonly FileType ZIP_7z_2 = new([0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C], "7z", "application/x-compressed");
    public static readonly FileType ZIP = new([0x50, 0x4B, 0x03, 0x04 ], "zip", "application/x-compressed");
    public static readonly FileType RAR = new([0x52, 0x61, 0x72, 0x21 ], "rar", "application/x-compressed");

    //Compressed tape archive file using standard (Lempel-Ziv-Welch) compression
    public static readonly FileType TAR_ZV = new([0x1F, 0x9D ], "tar.z", "application/x-tar");
                                                  
    //Compressed tape archive file using LZH (Lempiv-Huffman) compression
    public static readonly FileType TAR_ZH = new([0x1F, 0xA0 ], "tar.z", "application/x-tar");

    //bzip2 compressed archive
    public static readonly FileType BZ2 = new([ 0x42, 0x5A, 0x68 ], "tar", "application/x-bzip2");

    #endregion Zip, 7zip, rar, tar, bz2, gz, tgz

    //Specific Files detected as text (Without Signature)

    #region Specific Text Files html, json

    //HTML
    public static readonly FileType HTML = new([], "html", "text/html");

    //JSON
    public static readonly FileType JSON = new([], "json", "text/json");

    #endregion Specific Text Files html, json

    public static List<FileType> AllAvailableFormats()

    {
        return
        [
            PDF, DOC, XLS, ZIP, RAR, RTF, PNG, PPT,
            ZIP_7z, ZIP_7z_2, GZ, TGZ, TAR_ZH, JPEG,
            TAR_ZV, ICO, XML, TXT_UTF8, TXT_UTF16_BE,
            TXT_UTF16_LE, TXT_UTF32_BE, TXTUTF32LE
        ];
    }
}