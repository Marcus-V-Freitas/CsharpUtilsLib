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

    public static long GetDirectorySizeContent(string directoryPath)
    {
        DirectoryInfo directory = new DirectoryInfo(directoryPath);

        long size = 0;

        foreach (FileInfo file in directory.GetFiles())
        {
            size += file.Length;
        }

        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            size += GetDirectorySizeContent(subDirectory.FullName);
        }

        return size;
    }

    public static void RenameFile(string filePath, string newName)
    {
        string newFilePath = Path.Combine(Path.GetDirectoryName(filePath)!, newName);
        File.Move(filePath, newFilePath);
    }

    public static void ClearDirectoryContent(string directoryPath)
    {
        DirectoryInfo directory = new DirectoryInfo(directoryPath);

        foreach (FileInfo file in directory.GetFiles())
        {
            file.Delete();
        }

        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            subDirectory.Delete(true);
        }
    }

    public static void CopyDirectoryContent(string sourceDirectory, string targetDirectory)
    {
        CreateDirectoryIfNotExists(targetDirectory);

        foreach (string file in Directory.GetFiles(sourceDirectory))
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(targetDirectory, fileName);
            File.Copy(file, destFile, true);
        }

        foreach (string subDirectory in Directory.GetDirectories(sourceDirectory))
        {
            string name = Path.GetFileName(subDirectory);
            string destDirectory = Path.Combine(targetDirectory, name);
            CopyDirectoryContent(subDirectory, destDirectory);
        }
    }

    public static void CreateTextFileWithContent(string directoryPath, string fileName, string fileContent)
    {
        string filePath = Path.Combine(directoryPath, fileName);
        using (var writer = new StreamWriter(filePath))
        {
            writer.Write(fileContent);
        }
    }

    public static void MergeFiles(string[] fileNames, string outputFileName)
    {
        using (var output = File.Create(outputFileName))
        {
            foreach (string file in fileNames)
            {
                using (var input = File.OpenRead(file))
                {
                    input.CopyTo(output);
                }
            }
        }
    }
}