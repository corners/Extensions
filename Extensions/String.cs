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

	}
}
