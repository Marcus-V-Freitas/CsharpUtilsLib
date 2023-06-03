namespace CsharpUtilsLib.Collection;

public static class Collections
{
    public static string ConcatLists(this List<string> texts, string separator = "")
    {
        StringBuilder sb = new StringBuilder();
        texts.ForEach(text => sb.AppendLine($"{text}{separator}"));
        return sb.ToString();
    }

    public static T GetRandomElement<T>(this IList<T> collection)
    {
        return collection[SafeRandom.Next(collection.Count)];
    }

    public static int[] BubbleSort(this int[] numbers)
    {
        int temp;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    temp = numbers[j + 1];
                    numbers[j + 1] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
        return numbers;
    }

    public static T MostFrequent<T>(this IEnumerable<T> list)
    {
        if (list.ListIsNullOrEmpty())
        {
            return default!;
        }

        var frequencies = new Dictionary<T, int>();

        foreach (T item in list)
        {
            if (frequencies.TryGetValue(item, out int frequency))
            {
                frequencies[item] = frequency + 1;
            }
            else
            {
                frequencies.Add(item, 1);
            }
        }

        return frequencies.OrderByDescending(x => x.Value)
                          .FirstOrDefault().Key;
    }

    public static bool DictionaryIsNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue> source)
    {
        return source.DictionaryIsNull() || source.DictionaryIsEmpty();
    }

    public static bool DictionaryIsNull<TKey, TValue>(this IDictionary<TKey, TValue> source)
    {
        return source == null;
    }

    public static bool DictionaryIsEmpty<TKey, TValue>(this IDictionary<TKey, TValue> source)
    {
        return !source.Any();
    }

    public static bool ListIsNullOrEmpty<T>(this IEnumerable<T> source)
    {
        return source.ListIsNull() || source.ListIsEmpty();
    }

    public static bool ListIsNull<T>(this IEnumerable<T> source)
    {
        return source == null;
    }

    public static bool ListIsEmpty<T>(this IEnumerable<T> source)
    {
        return !source.Any();
    }

    public static bool AddIfNotEmptyOrNull(this List<string> source, string value)
    {
        if (!source.ListIsNull() && !string.IsNullOrEmpty(value))
        {
            source.Add(value);
            return true;
        }

        return false;
    }

    public static bool AddIfNotNull<T>(this ICollection<T> source, T item)
    {
        if (!source.ListIsNull() && item != null)
        {
            source.Add(item);
            return true;
        }

        return false;
    }

    public static bool AddIfNotNull<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
    {
        if (!source.ListIsNull() && key != null && value != null)
        {
            source.Add(key, value);
            return true;
        }

        return false;
    }

    public static bool AddOrChangeValue<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
    {
        if (source.ListIsNull() || key == null || value == null)
        {
            return false;
        }

        if (source.ContainsKey(key))
        {
            source[key] = value;
            return true;
        }
        else
        {
            return source.AddIfNotNull(key, value);
        }
    }

    public static bool AddOrChangeValueByIndex<TKey, TValue>(this IDictionary<TKey, TValue> source, TValue value, int index)
    {
        if (index < 0 || source.ListIsNull() || source.Count <= index)
        {
            return false;
        }

        TKey key = source.Keys.ElementAt(index);

        return source.AddOrChangeValue(key, value);
    }

    public static bool KeyValueIsNull<TKey, TValue>(this KeyValuePair<TKey, TValue> source)
    {
        return source.Key == null || source.Value == null;
    }

    public static bool KeyValueIsNullOrEmpty(this KeyValuePair<string, string> keyValuePair)
    {
        return (string.IsNullOrEmpty(keyValuePair.Key) || string.IsNullOrEmpty(keyValuePair.Value));
    }

    public static bool AddRangeIfNotNullOrEmpty<T>(this ICollection<T> source, IEnumerable<T> items)
    {
        if (source.ListIsNull() || items.ListIsNullOrEmpty())
        {
            return false;
        }

        foreach (var item in items)
        {
            source.AddIfNotNull(item);
        }

        return true;
    }

    public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
    {
        if (!source.ListIsNullOrEmpty() && source.TryGetValue(key, out TValue? result))
        {
            return result;
        }

        return default!;
    }

    public static T TryGetValue<T>(this T[] array, int index)
    {
        if (!array.ListIsNullOrEmpty() && array.Length > index)
        {
            return array[index];
        }

        return default!;
    }

    public static T TryGetValue<T>(this IList<T> list, int index)
    {
        if (!list.ListIsNullOrEmpty() && list.Count > index)
        {
            return list[index];
        }

        return default!;
    }

    public static TValue TryGetValue<TKey, TValue>(this IList<KeyValuePair<TKey, TValue>> source, TKey key)
    {
        TValue result;

        if (!source.ListIsNullOrEmpty() && key != null &&
            (result = source.FirstOrDefault(x => x.Key!.Equals(key)).Value) != null)
        {
            return result;
        }

        return default!;
    }

    public static List<T> ToNullList<T>(this IEnumerable<T> source)
    {
        if (source.ListIsNullOrEmpty())
        {
            return null!;
        }

        return source.ToList();
    }

    public static List<T> ToDefaultListIfNull<T>(this IEnumerable<T> source)
    {
        if (source.ListIsNull())
        {
            return new();
        }

        return source.ToList();
    }

    public static List<T> ToDistinctList<T>(this IEnumerable<T> source)
    {
        return source.Distinct().ToList();
    }
}