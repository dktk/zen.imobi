using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Base.Tests
{
    public class ObjectExtensions
    {
        [Fact]
        public void IsNull()
        {
            object obj = null;

            Assert.True(obj.IsNull());
        }

        [Theory]
        [AutoData]
        public void IsNotNull(object obj)
        {
            Assert.True(obj.IsNotNull());
        }
    }
}