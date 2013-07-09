using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Extensions
{
	public static class Object
	{
		public static KeyValuePair<TKey, TValue> Pair<TKey, TValue>(this TKey key, TValue value)
		{
			return new KeyValuePair<TKey, TValue>(key, value);
		}

	
		public static bool TryCast<T>(this object source, out T value) where T : class
		{
			value = source as T;
			return source != null;
		}

		///<summary>
		/// Converts an object into a dictionary
		///</summary>
		///<param name="target">The object</param>
		///<param name="nullHandler">Handler for null value</param>
		///<returns>Dictionary built from the objects properties</returns>
		public static IDictionary<string, object> ToDictionary(this object target, Func<string, object> nullHandler = null)
		{
			if (target == null)
			{
				return new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
			}

			var properties = TypeDescriptor.GetProperties(target);

			var hash = new Dictionary<string, object>(properties.Count, StringComparer.InvariantCultureIgnoreCase);

			foreach (PropertyDescriptor descriptor in properties)
			{
				var key = descriptor.Name;
				var value = descriptor.GetValue(target);

				if (value != null)
				{
					hash.Add(key, value);
				}
				else if (nullHandler != null)
				{
					hash.Add(key, nullHandler(key));
				}
			}

			return hash;
		}
	}
}
