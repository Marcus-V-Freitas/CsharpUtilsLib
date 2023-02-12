namespace CsharpUtilsLib.FileDirectory;

public static class FilesDirectories
{
    public static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
            }
            catch { }
        }
    }

    public static void DeleteFolder(string folder, bool recursive = false)
    {
        if (Directory.Exists(folder))
        {
            try
            {
                Directory.Delete(folder, recursive);
            }
            catch { }
        }
    }

    public static bool IsXML(byte[] bytes)
    {
        try
        {
            // Put the byte array into a stream and rewind it to the beginning
            using (var ms = new MemoryStream(bytes))
            {
                ms.Flush();
                ms.Position = 0;
                var myDoc = new XmlDocument();
                myDoc.Load(ms);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsJson(string text)
    {
        try
        {
            JsonSerializer.Deserialize<dynamic>(text);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsHTML(string text)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(text);

        //Return if nodes are simple text or html
        return !doc.DocumentNode.Descendants().All(n => n.NodeType == HtmlNodeType.Text) &&
                doc.DocumentNode.SelectSingleNode("html") != null;
    }



    public static void CreateDirectoryIfNotExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public static void CreateFileIfNotExists(string fileName)
    {
        if (!File.Exists(fileName))
        {
            File.Create(fileName);
        }
    }

    public static void CreateLocalFileIfNotExists(string fileName)
    {
        var currentDir = Directory.GetCurrentDirectory();

        var fullPath = Path.Combine(currentDir, fileName);

        CreateFileIfNotExists(fullPath);
    }

    public static void CreateLocalDirectoryIfNotExists(string path)
    {
        var currentDir = Directory.GetCurrentDirectory();

        var fullPath = Path.Combine(currentDir, path);

        CreateDirectoryIfNotExists(fullPath);
    }
}