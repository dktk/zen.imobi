using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Base
{
    public static class FuncExtensions
    {
        public static readonly ConcurrentDictionary<string, object> CachedValues = new ConcurrentDictionary<string, object>();

        public static T Memoize<T>(this Func<T> f, string key)
        {
            return (T)CachedValues.GetOrAdd(key, k => f());
        }

        public static T Timeout<T>(this Func<T> f, int duration)
        {
            Contract.Requires(duration > 0);

            var source = new CancellationTokenSource(duration);

            return Task.Factory.StartNew(f, source.Token).Result;
        }

        public static Func<T> TimeIt<T>(this Func<T> f, Action<TimeSpan> action)
        {
            Guard.AgainstNullOrEmpty(action);

            var watch = new Stopwatch();
            watch.Start();

            var value = f();

            watch.Stop();

            action(watch.Elapsed);

            // todo: this needs to log using a logger
            return () => value;
        }
    }
}