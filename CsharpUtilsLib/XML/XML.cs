namespace CsharpUtilsLib.XML;

public static class XML
{
    public static string GetElementValue(this XmlDocument doc, string elementName, string namespaceURI = null!)
    {
        XmlNode node;
        if (namespaceURI != null)
        {
            var manager = new XmlNamespaceManager(doc.NameTable);
            manager.AddNamespace("ns", namespaceURI);
            node = doc.SelectSingleNode("//ns:" + elementName, manager)!;
        }
        else
        {
            node = doc.SelectSingleNode("//" + elementName)!;
        }

        return node?.InnerText!;
    }

    public static XmlElement AddElement(this XmlDocument doc, string elementName, string namespaceURI = null!)
    {
        var element = doc.CreateElement(elementName, namespaceURI);
        doc.DocumentElement?.AppendChild(element);
        return element;
    }

    public static string GetAttributeValue(this XmlElement element, string attributeName)
    {
        return element?.Attributes?[attributeName]?.Value!;
    }

    public static void RemoveElement(this XmlDocument doc, XmlElement element)
    {
        doc?.ParentNode?.RemoveChild(element);
    }

    public static XmlElement ToXmlElement<T>(this T obj, string elementName, string namespaceURI = null!)
    {
        var serializer = new XmlSerializer(typeof(T), namespaceURI);
        var doc = new XmlDocument();
        using (var writer = doc.CreateNavigator()!.AppendChild())
        {
            serializer.Serialize(writer, obj);
        }

        return doc.DocumentElement!;
    }

    public static T ToObject<T>(this XmlElement element)
    {
        var serializer = new XmlSerializer(typeof(T), element.NamespaceURI);
        using (var reader = new XmlNodeReader(element))
        {
            return (T)serializer.Deserialize(reader)!;
        }
    }

    public static string SerializeObjectToXml<T>(T obj)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (StringWriter textWriter = new StringWriter())
        {
            xmlSerializer.Serialize(textWriter, obj);
            return textWriter.ToString();
        }
    }

    public static T DeserializeXmlToObject<T>(string xml)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (StringReader textReader = new StringReader(xml))
        {
            return (T)xmlSerializer.Deserialize(textReader)!;
        }
    }
}