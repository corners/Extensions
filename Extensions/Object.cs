using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ZeroTwoTwelve.Extensions
{
    /// <summary>
    /// Extension methods for objects
    /// </summary>
    public static class ObjectExtensions
	{
        /// <summary>
        /// Creates a KeyValuePair with another object.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static KeyValuePair<TKey, TValue> PairedWith<TKey, TValue>(this TKey key, TValue value)
		{
			return new KeyValuePair<TKey, TValue>(key, value);
		}

        /// <summary>
        /// Creates a KeyValuePair with another object.
        /// </summary>
        /// <remarks>Old way. Use PairedWith instead.</remarks>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static KeyValuePair<TKey, TValue> Pair<TKey, TValue>(this TKey key, TValue value)
        {
            return PairedWith(key, value);
        }


        /// <summary>
        /// Tries to cast the object to type T and returns true if successful.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="value">Value to attempt to cast.</param>
        /// <param name="result">Value cast to target type.</param>
        /// <returns>True if the cast was successful otherwise false.</returns>
        public static bool TryCast<T>(this object value, out T result) where T : class
        {
            result = value as T;
            return (result != null);
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
