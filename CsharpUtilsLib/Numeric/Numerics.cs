namespace CsharpUtilsLib.Numeric;

public static class Numerics
{
    public static int ConvertToInt(this string text, int defaultValue = default)
    {
        return (int)ConvertToNullInt(text, defaultValue)!;
    }

    public static int? ConvertToNullInt(this string text, int? defaultValue = default)
    {
        if (string.IsNullOrEmpty(text))
        {
            return defaultValue;
        }

        if (int.TryParse(Texts.OnlyNumbers(text), NumberStyles.Any, CultureInfo.InvariantCulture, out int number))
        {
            return number;
        }

        return defaultValue;
    }

    public static double ConvertToDouble(this string text, double defaultValue = default, bool onlyNumbers = true)
    {
        return (double)ConvertToNullDouble(text, defaultValue, onlyNumbers)!;
    }

    public static double? ConvertToNullDouble(this string text, double? defaultValue = default, bool onlyNumbers = true)
    {
        if (string.IsNullOrEmpty(text))
        {
            return defaultValue;
        }

        if (double.TryParse(onlyNumbers ? text.OnlyNumbers() : text, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
        {
            return number;
        }

        return defaultValue;
    }

    public static double CalculateLoanCost(double principal, double interestRate, int numYears)
    {
        int numPeriods = numYears * 12;
        double monthlyInterestRate = interestRate / 1200; // divide by 100 to convert to decimal and by 12 to get the monthly fee
        double loanCost = principal * Math.Pow(1 + monthlyInterestRate, numPeriods) * monthlyInterestRate / (Math.Pow(1 + monthlyInterestRate, numPeriods) - 1);

        return loanCost;
    }

    public static double CalculateNetPresentValue(double discountRate, params double[] cashFlows)
    {
        if (cashFlows.ListIsNullOrEmpty())
        {
            return 0;
        }

        double npv = -cashFlows[0];

        for (int i = 1; i < cashFlows.Length; i++)
        {
            npv += cashFlows[i] / Math.Pow(1 + discountRate, i);
        }

        return npv;
    }

    public static int GetLongestSequence(int[] numbers)
    {
        int maxLength = 0;
        int currentLength = 1;
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                currentLength++;
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }
                currentLength = 1;
            }
        }
        if (currentLength > maxLength)
        {
            maxLength = currentLength;
        }
        return maxLength;
    }

    public static List<int> RandomNumbers(int count, int min, int max)
    {
        var numbers = new List<int>();

        for (int i = 0; i < count; i++)
        {
            numbers.Add(SafeRandom.Next(min, max));
        }
        return numbers;
    }

    public static bool IsInRange(int number, int lowerBound, int upperBound)
    {
        return (number >= lowerBound) && (number <= upperBound);
    }

    public static List<int> GetMissingNumbers(this int[] numbers)
    {
        int max = numbers.Max();
        var missingNumbers = new List<int>();

        for (int i = 1; i <= max; i++)
        {
            if (!numbers.Contains(i))
            {
                missingNumbers.Add(i);
            }
        }
        return missingNumbers;
    }

    public static bool IsNumeric(this string input)
    {
        return long.TryParse(input, out _);
    }

    public static double GetAverage(this IEnumerable<int> numbers)
    {
        return numbers.Average();
    }

    public static int Factorial(this int number)
    {
        if (number <= 1)
        {
            return 1;
        }

        int result = 1;
        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }

        return result;
    }

    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }

    public static bool IsOdd(this int number)
    {
        return (number % 2 != 0);
    }

    public static bool IsPrime(this int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static double StandardDeviation(this IEnumerable<double> values)
    {
        if (values.ListIsNullOrEmpty())
        {
            return 0;
        }

        double mean = values.Average();
        double sumOfSquares = values.Sum(x => Math.Pow(x - mean, 2));
        return Math.Sqrt(sumOfSquares / values.Count());
    }

    public static double Median(this IEnumerable<double> numbers)
    {
        List<double> sortedNumbers = numbers.OrderBy(n => n).ToList();
        int count = sortedNumbers.Count;

        if (count % 2 == 0)
        {
            int middle = count / 2;
            return (sortedNumbers[middle - 1] + sortedNumbers[middle]) / 2.0;
        }
        else
        {
            return sortedNumbers[count / 2];
        }
    }

    public static double Average<T>(this IEnumerable<T> source, Func<T, double> selector)
    {
        if (source.ListIsNullOrEmpty())
        {
            return 0;
        }

        double sum = 0;
        int count = 0;

        foreach (T item in source)
        {
            sum += selector(item);
            count++;
        }

        return count > 0 ? sum / count : 0;
    }
}