using System;

namespace Base
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static void Match<T>(this T instance, Func<T, bool> errorPredicate = null, Action<Type> onError = null, Action<T> onSuccess = null)
            where T : class
        {
            if (instance == null || errorPredicate == null || errorPredicate(instance))
            {
                if (onError != null)
                {
                    onError(typeof(T));
                }

                return;
            }

            if (onSuccess != null)
            {
                onSuccess(instance);
            }
        }

        public static void Match<T, TException>(this T instance, Func<T, bool> errorPredicate, string message, Action<T> onSuccess = null)
            where T: class
            where TException : Exception, new()
        {
            instance
                .Match(
                    errorPredicate,
                    onError: _ => Guard.Throw<TException>(message),
                    onSuccess: _ => onSuccess(_)
                );
        }
    }
}