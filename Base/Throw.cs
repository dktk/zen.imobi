using System;

namespace Base
{
    public static class Throw
    {
        public static void FormattedException<TException>(string message, params object[] messageArgs)
            where TException : Exception, new()
        {
            Guard.AgainstNullOrEmpty(message);

            var msg = string.Format(message, messageArgs);

            var exception = Activator.CreateInstance(typeof(TException), msg);

            throw exception as TException;
        }

        public static void Exception<TException>(string message, params object[] exceptionArgs)
            where TException : Exception, new()
        {
            Guard.AgainstNullOrEmpty(message);

            var exception = Activator.CreateInstance(typeof(TException), exceptionArgs);

            throw exception as TException;
        }
    }
}