using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroTwoTwelve.Extensions
{
    /// <summary>
    /// Extension methods for Dictionaries
    /// </summary>
	public static class DictionaryExtensions
	{
		public static IDictionary<TKey, TValue> EmptyIfNull<TKey, TValue>(this IDictionary<TKey, TValue> collection, IEqualityComparer<TKey> comparer)
		{
			if (collection == null)
				return new Dictionary<TKey, TValue>(comparer);
			return collection;
		}

		public static IDictionary<TKey, TValue> EmptyIfNull<TKey, TValue>(this IDictionary<TKey, TValue> collection)
		{
			return DictionaryExtensions.EmptyIfNull(collection, EqualityComparer<TKey>.Default);
		}


		public static Dictionary<K, V> ShallowCopy<K, V>(this Dictionary<K, V> dict)
		{
			var result = from x in dict
						 select x;
			return result.ToDictionary(x => x.Key, x => x.Value, dict.Comparer);
		}

		/// <summary>
		/// Get value or throw an exception containing the key if the value does not exist.
		/// </summary>
		/// <typeparam name="K"></typeparam>
		/// <typeparam name="V"></typeparam>
		/// <param name="dict"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static V GetValue<K, V>(this IDictionary<K, V> dict, K key)
		{
			V result;
			bool found = dict.TryGetValue(key, out result);
			if (!found)
				throw new KeyNotFoundException(string.Format("Key '{0}' not found", key.ToString()));

			return result;
		}

		public static M GetValue<K, V, M>(this IDictionary<K, V> dict, K key, Func<V, M> selector)
		{
			V value = GetValue(dict, key);
			return selector(value);
		}

		public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> d, TKey key, TValue defaultValue)
		{
			TValue value;
			if (!d.TryGetValue(key, out value))
				value = defaultValue;
			return value;
		}

		public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> d, TKey key)
		{
			return DictionaryExtensions.ValueOrDefault(d, key, default(TValue));
		}

		public static void SetValue<TKey, TValue>(this IDictionary<TKey, TValue> d, TKey key, TValue value)
		{
			if (d.ContainsKey(key))
				d[key] = value;
			else
				d.Add(key, value);
		}
	}
}
