using System;

namespace Base
{
    public static class Throw
    {
        public static void FormattedException<TException>(string message, params object[] args)
            where TException : Exception, new()
        {
            Guard.AgainstNullOrEmpty(message);

            var msg = string.Format(message, args);

            var exception = Activator.CreateInstance(typeof(TException), msg);

            throw exception as TException;
        }

        public static void Exception<TException>(string message, params object[] args)
            where TException : Exception, new()
        {
            Guard.AgainstNullOrEmpty(message);

            var exception = Activator.CreateInstance(typeof(TException), args);

            throw exception as TException;
        }
    }
}