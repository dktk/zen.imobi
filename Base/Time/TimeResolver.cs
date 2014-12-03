using System;

namespace Base.Time
{
    public class TimeResolver : ITimeResolver
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}