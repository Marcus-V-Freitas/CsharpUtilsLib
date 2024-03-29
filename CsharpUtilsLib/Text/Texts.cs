﻿namespace CsharpUtilsLib.Text;

public static class Texts
{
    public static Encoding GetEncodingByName(string encodingName, Encoding defaultEncoding = null!)
    {
        defaultEncoding ??= Encoding.Default;

        if (string.IsNullOrEmpty(encodingName))
        {
            return defaultEncoding;
        }

        Encoding encoding = Encoding.GetEncodings()?
                                    .FirstOrDefault(e => e.Name.Equals(encodingName, StringComparison.OrdinalIgnoreCase))?
                                    .GetEncoding()!;

        return encoding ?? defaultEncoding;
    }

    public static string RemoveSpecialCharacters(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null!;
        }

        StringBuilder sb = new StringBuilder();
        foreach (char c in text)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    public static IEnumerable<string> SplitStringWithoutNullOrEmpty(this string text, string separator)
    {
        if (string.IsNullOrEmpty(text) || separator == null)
        {
            return Enumerable.Empty<string>();
        }

        IEnumerable<string> foundTexts = text.Split(new[] { separator }, StringSplitOptions.None);
        return foundTexts.Where(x => !string.IsNullOrEmpty(x));
    }

    public static string GenerateRandomPassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
                                    .Select(s => s[SafeRandom.Next(s.Length)])
                                    .ToArray());
    }

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
        if (input == null || value == null)
        {
            return 0;
        }

        int count = 0;
        int index = input.IndexOf(value, stringComparison);

        while (index != -1)
        {
            count++;
            index = input.IndexOf(value, index + value.Length, stringComparison);
        }
        return count;
    }

    public static bool AnyDigits(this string input)
    {
        return input != null && input.Any(char.IsDigit);
    }

    public static bool AllDigits(this string input)
    {
        return input != null && input.All(char.IsDigit);
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
        if (string.IsNullOrEmpty(text))
        {
            return null!;
        }

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
        document = document.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");

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

    public static string ConvertToString(this IEnumerable<char> source)
    {
        if (source.ListIsNullOrEmpty())
        {
            return null!;
        }

        StringBuilder sb = new StringBuilder();
        foreach (char c in source)
        {
            sb.Append(c);
        }

        return sb.ToString();
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
        if (value == null || substr == null)
        {
            return 0;
        }

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
        return new string((text ?? string.Empty).Where(c => Char.IsDigit(c)).ToArray());
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

    public static string ToRoman(this int number)
    {
        if (number < 1 || number > 3999)
        {
            return null!;
        }

        string[] romanNumerals = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
        int[] values = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };

        string roman = "";

        for (int i = 12; i >= 0; i--)
        {
            while (number >= values[i])
            {
                number -= values[i];
                roman += romanNumerals[i];
            }
        }
        return roman;
    }
}