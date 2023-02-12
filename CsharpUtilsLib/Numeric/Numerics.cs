namespace CsharpUtilsLib.Numeric;

public static class Numerics
{
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

}