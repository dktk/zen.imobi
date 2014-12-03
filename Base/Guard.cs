using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Base
{
    public static class Guard
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

        public static void Throw<TException>(string message, params object[] args)
            where TException : Exception, new()
        {
            var msg = string.Format(message, args);

            var exception = Activator.CreateInstance(typeof(TException), msg);

            throw exception as TException;
        }
    }
}