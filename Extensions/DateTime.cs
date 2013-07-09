using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
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

    }
}
