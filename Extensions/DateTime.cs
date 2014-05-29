using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroTwoTwelve.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime ToMidnight(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, dt.Kind);
        }

        public static bool InRange(this DateTime dt, DateTime fromInclusive, DateTime toExclusive)
        {
            return (dt >= fromInclusive && dt < toExclusive);
        }

        public static int GetWeekOfYear(this DateTime date)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                date,
                CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
            );
        }

        public static DateTime LastWorkingDay(this DateTime date, IEnumerable<DayOfWeek> workDays)
        {
            DateTime result = date.ToMidnight();
            do
            {
                result = result.AddDays(-1);
            } while (!workDays.Contains(result.DayOfWeek));

            return result;
        }


        public static int WeekNumber(this DateTime date)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            return cal.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public static DateTime Max(DateTime a, DateTime b)
        {
            if (a >= b)
                return a;
            else
                return b;
        }

        public static DateTime Min(DateTime a, DateTime b)
        {
            if (a <= b)
                return a;
            else
                return b;
        }

        public static IEnumerable<DateTime> DaysInRange(this DateTime from, DateTime toExclusive)
        {
            if (toExclusive.Subtract(from).TotalDays < 0)
                throw new ArgumentException("'from' date must be earlier than 'to' date.");

            var lastDay = toExclusive.AddDays(-1);
            for (var date = from; date <= lastDay; date = date.AddDays(1))
            {
                yield return date.ToMidnight();
            }
        }
    }
}
