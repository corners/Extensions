using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
	public static class StringBuilderExtensions
	{
		public static void AppendWhen(this StringBuilder sb, bool condition, string text)
		{
			if (condition)
				sb.Append(text);
		}
	}
}
