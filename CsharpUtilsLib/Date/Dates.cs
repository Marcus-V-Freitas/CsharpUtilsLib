namespace CsharpUtilsLib.Date;

public static class Dates
{
    public static int CalculateAge(this DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }

    public static DateTime ConvertMillisecondsToDateTime(this long milliseconds)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds).DateTime;
    }

    public static DateTime ConvertToDatetime(this string value, string format = "dd/MM/yyyy", string culture = "", DateTime defaultValue = default)
    {
        CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        if (string.IsNullOrEmpty(value))
        {
            return defaultValue;
        }

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

    public static DateTime? TryConvertDatetime(this string value, string format = "dd/MM/yyyy", string culture = "", DateTime? defaultValue = null)
    {
        CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        if (string.IsNullOrEmpty(value))
        {
            return defaultValue;
        }

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

    public static IEnumerable<DateTime> GetAllYearDates(int year)
    {
        List<DateTime> dates = new();
        var currentDate = new DateTime(year, 1, 1);

        while (currentDate.Year == year)
        {
            dates.Add(currentDate);
            currentDate = currentDate.AddDays(1);
        }

        return dates;
    }

    public static DateTime GetLastDayOfWeek(this DateTime date)
    {
        int diff = (7 - (date.DayOfWeek - DayOfWeek.Monday)) % 7;
        return date.AddDays(diff).Date;
    }

    public static DateTime GetFirstDayOfWeek(this DateTime date)
    {
        int delta = DayOfWeek.Monday - date.DayOfWeek;
        if (delta > 0)
        {
            delta -= 7;
        }
        return date.AddDays(delta);
    }

    public static DateTime LastDayOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }

    public static DateTime LastDayOfMonth(int year, int month)
    {
        return new DateTime(year, month, DateTime.DaysInMonth(year, month));
    }

    public static int GetAge(this DateTime birthDate)
    {
        int age = DateTime.Now.Year - birthDate.Year;
        if (DateTime.Now.Month < birthDate.Month || DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day)
        {
            age--;
        }
        return age;
    }

    public static bool IsWeekend(this DateTime date)
    {
        return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
    }

    public static bool IsWeekday(this DateTime date)
    {
        return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
    }

    public static bool IsBetweenDates(this DateTime date, DateTime startDate, DateTime endDate)
    {
        return (date >= startDate && date <= endDate);
    }
    public static DateTime GetNextWeekday(this DateTime start)
    {
        var next = start;
        while (!IsWeekday(next))
        {
            next = next.AddDays(1);
        }
        return next;
    }

    public static int GetWeekdayCount(this DateTime start, DateTime end)
    {
        int count = 0;
        for (var date = start; date <= end; date = date.AddDays(1))
        {
            if (IsWeekday(date))
            {
                count++;
            }
        }
        return count;
    }

    public static int DaysBetweenDates(this DateTime startDate, DateTime endDate)
    {
        return (endDate - startDate).Days;
    }

    public static bool IsLeapYear(this int year)
    {
        return DateTime.IsLeapYear(year);
    }

    public static DateTime GetLastDayOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }

    public static List<DateTime> GenerateDateRange(this DateTime startDate, DateTime endDate)
    {
        List<DateTime> dates = new List<DateTime>();
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            dates.Add(date);
        }
        return dates;
    }

    public static bool IsDateInRange(this DateTime date, DateTime startDate, DateTime endDate)
    {
        return date >= startDate && date <= endDate;
    }

    public static int GetDaysUntilDate(this DateTime date)
    {
        return (date - DateTime.Now.Date).Days;
    }
}