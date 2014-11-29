using System.Collections.Generic;
using System.Linq;

namespace Base
{
    public static class ListExtensions
    {
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection != null && collection.Any();
        }
    }
}