using Moq;
using Ploeh.AutoFixture.Xunit;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Base.Tests
{
    public class FuncExtensionTests
    {
        [Theory]
        [AutoData]
        public void Memoize(string dummyResult)
        {
            var counter = 0;
            Func<string> dummy = () =>
            {
                counter++;

                return dummyResult;
            };

            var result1 = dummy.Memoize("getData1");
            var result2 = dummy.Memoize("getData1");
            var result3 = dummy.Memoize("getData1");

            Assert.Equal(1, counter);
        }

        [Theory]
        [AutoData]
        public void TimeIt(string dummyValue)
        {
            Func<string> dummy = () =>
            {
                Task.Delay(400);

                return dummyValue;
            };

            int miliseconds = 0;
            dummy.TimeIt(duration => 
            {
                miliseconds = duration.Milliseconds;
            });

            Assert.True(miliseconds > 0);
        }
    
        [Fact]
        public void Timeout()
        {
            Func<Guid> dummy = () =>
            {
                Task.Delay(1000);

                return Guid.Empty;
            };

            var result = dummy.Timeout(100);

            Assert.Equal(Guid.Empty, result);
        }
    }
}