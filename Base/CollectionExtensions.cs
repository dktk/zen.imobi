using System;
using System.Collections.Generic;
using System.Linq;

namespace Base
{
    public static class CollectionExtensions
    {
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.IsNullOrEmpty();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection, Func<T, bool> predicate = null)
        {
            if (collection == null)
            {
                return true;
            }

            if (predicate != null)
            {
                return !collection.Any(predicate);
            }

            return !collection.Any();
        }

        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary == null)
            {
                dictionary = new Dictionary<TKey, TValue>();
                dictionary.Add(key, default(TValue));

                return dictionary[key];
            }

            if (dictionary.Keys.IsNullOrEmpty(k => k.Equals(key)))
            {
                dictionary.Add(key, default(TValue));
            }

            return dictionary[key];
        }
    }
}