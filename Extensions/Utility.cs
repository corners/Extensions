using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroTwoTwelve.Extensions
{
	/// <summary>
	/// Misc utility functions.
	/// </summary>
	public static class Utility
	{
		public static KeyValuePair<TKey, TValue> Pair<TKey, TValue>(TKey key, TValue value)
		{
			return new KeyValuePair<TKey, TValue>(key, value);
		}
	}
}
