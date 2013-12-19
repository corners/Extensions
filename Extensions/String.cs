using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
	public static class StringExtensions
	{
		public static bool EqualsInvariant(this string leftValue, string rightValue)
		{
			return leftValue.Equals(rightValue, StringComparison.InvariantCultureIgnoreCase);
		}

        /// <summary>
        /// Repeat the supplied string 'count' number of times.
        /// </summary>
        /// <param name="value">Value to repeat</param>
        /// <param name="count">Number of times to repeat</param>
        /// <returns>String containing the initial value repeated 'count' times.</returns>
        public static string Repeat(this string value, int count)
        {
            var builder = new StringBuilder(Math.Max(1024, value.Length * count));
            for (var i = 0; i < count; i++)
                builder.Append(value);
            return builder.ToString();
        }
    }
}
