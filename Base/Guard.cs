using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Base
{
    public class Guard
    {
        public static void AgainstNullOrEmpty(string value)
        {
            Contract.Requires<ArgumentNullException>(value.IsNotNullOrEmpty());
        }

        public static void AgainstNullOrEmpty(Guid value)
        {
            Contract.Requires<ArgumentNullException>(value != Guid.Empty);
        }

        public static void AgainstNullOrEmpty(object value)
        {
            Contract.Requires<ArgumentNullException>(value != null);
        }

        public static void ConstructorAssignment<T>(T field, T value)
        {
            Contract.Requires<ArgumentNullException>(!value.Equals(default(T)));
            Contract.Ensures(field.Equals(value));
        }
    }
}