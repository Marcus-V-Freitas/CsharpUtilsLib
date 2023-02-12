namespace CsharpUtilsLib.Text;

public static class Texts
{
    public static bool IsSequentialRepetition(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false!;
        }

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    public static string RemoveAllWhitespace(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        char[] sourceChar = input.ToCharArray();
        int destinyIndex = 0;

        foreach (int i in Enumerable.Range(0, input.Length))
        {
            char actualChar = sourceChar[i];
            switch (actualChar)
            {
                case '\u0020':
                case '\u00A0':
                case '\u1680':
                case '\u2000':
                case '\u2001':
                case '\u2002':
                case '\u2003':
                case '\u2004':
                case '\u2005':
                case '\u2006':
                case '\u2007':
                case '\u2008':
                case '\u2009':
                case '\u200A':
                case '\u202F':
                case '\u205F':
                case '\u3000':
                case '\u2028':
                case '\u2029':
                case '\u0009':
                case '\u000A':
                case '\u000B':
                case '\u000C':
                case '\u000D':
                case '\u0085':
                    break;
                default:
                    sourceChar[destinyIndex++] = actualChar;
                    break;
            }
        }
        return new string(sourceChar, 0, destinyIndex);
    }

    public static string MultiReplace(this string input, List<string> listDelimiters, string newVal)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        StringBuilder sb = new StringBuilder(input);
        foreach (string delimiter in listDelimiters)
        {
            sb.Replace(delimiter, newVal);
        }
        return sb.ToString();
    }

    public static string GetMostFrequentSeparator(this string input, List<string> separators)
    {
        if (separators.ListIsNullOrEmpty())
        {
            return null!;
        }

        // Initialize variables with default values
        string separator = separators.FirstOrDefault()!;
        int count = 1;

        // Iterate and identity separator by occurrences count
        foreach (string item in separators)
        {
            int currentCount = CountOcurrences(input, item);
            if (currentCount > count)
            {
                count = currentCount;
                separator = item;
            }
        }
        return separator;
    }

    public static int CountOcurrences(this string input, string value, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
    {
        int count = 0;
        int index = input.IndexOf(value, stringComparison);

        while (index != -1)
        {
            count++;
            index = input.IndexOf(value, index + value.Length, stringComparison);
        }
        return count;
    }

    public static string RemoveDiacritics(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        var normalizedString = input.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }

    public static string MatchFirstOcurrency(this string input, string regex)
    {
        if (string.IsNullOrEmpty(input))
            input = string.Empty;

        return Regex.Match(input, @$"{regex}", RegexOptions.Compiled).Value ?? string.Empty;
    }

    public static List<string> MatchListOcurrencies(this string input, string regex)
    {
        if (string.IsNullOrEmpty(input))
            input = string.Empty;

        return Regex.Matches(input, @$"{regex}", RegexOptions.Compiled)
                    .Where(x => x.Success && !string.IsNullOrEmpty(x.Value))
                    .Select(x => x.Value)
                    .ToList();
    }

    public static string RemoveDuplicateWords(string text)
    {
        string[] words = text.Split(' ');
        HashSet<string> uniqueWords = new HashSet<string>(words);
        return string.Join(" ", uniqueWords);
    }

    public static string GetUniqueKey(int size)
    {
        char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        byte[] data = new byte[size];
        using (var crypto = new RNGCryptoServiceProvider())
        {
            crypto.GetBytes(data);
        }
        StringBuilder result = new StringBuilder(size);
        foreach (byte b in data)
        {
            result.Append(chars[b % chars.Length]);
        }
        return result.ToString();
    }

    public static string RemoveDocumentMask(string document)
    {
        if (string.IsNullOrEmpty(document))
        {
            return null!;
        }

        document = document.Trim();
        document = document.Replace(".", "").Replace("-", "").Replace(" ", "");

        return document;
    }

    public static string ToTitleCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(input.ToLower());
    }

    public static DateTime ConvertToDatetime(this string value, string format = "dd/MM/yyyy", string culture = "", DateTime defaultValue = default)
    {
        CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        if (!string.IsNullOrEmpty(culture))
        {
            cultureInfo = CultureInfo.GetCultureInfo(culture);
        }

        if (DateTime.TryParseExact(value, format, cultureInfo, DateTimeStyles.AllowWhiteSpaces, out DateTime date))
        {
            return date;
        }
        return defaultValue;
    }


    public static string[] SpecificSplit(this string value, char delimiter, int maxSplit = 0)
    {
        if (string.IsNullOrEmpty(value))
        {
            return new string[] { string.Empty };
        }

        if (maxSplit == 0)
        {
            return value.Split(delimiter);
        }

        if (value.Count(x => x == delimiter) + 1 >= maxSplit)
        {
            return value.Split(new char[] { delimiter }, maxSplit);
        }

        return new string[] { value };
    }

    public static string[] SpecificSplit(this string value, string delimiter, int maxSplit = 0)
    {
        if (string.IsNullOrEmpty(value))
        {
            return new string[] { string.Empty };
        }

        if (maxSplit == 0)
        {
            return value.Split(delimiter);
        }

        if (value.Count(delimiter) + 1 >= maxSplit)
        {
            return value.Split(delimiter, maxSplit);
        }

        return new string[] { value };
    }

    public static int Count(this string value, string substr, StringComparison strComp = StringComparison.CurrentCulture)
    {
        int count = 0, index = value.IndexOf(substr, strComp);
        while (index != -1)
        {
            count++;
            index = value.IndexOf(substr, index + substr.Length, strComp);
        }
        return count;
    }

    public static string OnlyNumbers(this string text)
    {
        return new string(text.Where(c => Char.IsDigit(c)).ToArray());
    }

    public static string SafeSubstring(this string value, int startIndex, int length)
    {
        return new string((value ?? string.Empty).Skip(startIndex).Take(length).ToArray());
    }
    public static byte[] ToByteArray(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null!;
        }
        return Encoding.UTF8.GetBytes(text);
    }

    public static byte[] ToByteArrayAscii(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null!;
        }
        return Encoding.ASCII.GetBytes(text);
    }

    public static string ToAscii(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null!;
        }
        return Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(text));
    }

    public static string ToUTF8(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null!;
        }
        return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(text));
    }

    public static string ToAscii(this byte[] bytes)
    {
        try
        {
            if (bytes == null)
            {
                return string.Empty;
            }
            return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
        }
        catch
        {
            return string.Empty;
        }
    }

    public static string ToUTF8(this byte[] bytes)
    {
        try
        {
            if (bytes == null)
            {
                return string.Empty;
            }
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
        catch
        {
            return string.Empty;
        }
    }
}