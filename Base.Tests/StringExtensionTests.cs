using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Base.Tests
{
    public class StringExtensionTests
    {
        [Fact]
        public void IsNullOrEmpty()
        {
            string nullString = null;
            string emptyString = string.Empty;

            Assert.True(nullString.IsNullOrEmpty());
            Assert.True(emptyString.IsNullOrEmpty());
        }

        [Theory]
        [AutoData]
        public void IsNotNullOrEmpty(string value)
        {
            Assert.True(value.IsNotNullOrEmpty());
        }
    }
}