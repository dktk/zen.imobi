using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Base.Tests
{
    public class LIstExtensionTests
    {
        [Fact]
        public void IsNotNullOrEmpty()
        {
            IEnumerable<string> nullCollection = null;
            IEnumerable<string> emptyCollection = Enumerable.Empty<string>();
            IEnumerable<string> collection = new [] { "1" };

            Assert.False(nullCollection.IsNotNullOrEmpty());
            Assert.False(emptyCollection.IsNotNullOrEmpty());
            Assert.True(collection.IsNotNullOrEmpty());
        }

        [Fact]
        public void IsNullOrEmpty()
        {
            IEnumerable<string> nullCollection = null;
            IEnumerable<string> emptyCollection = Enumerable.Empty<string>();
            IEnumerable<string> collection = new[] { "1" };

            Assert.True(nullCollection.IsNullOrEmpty());
            Assert.True(emptyCollection.IsNullOrEmpty());
            Assert.False(collection.IsNullOrEmpty());
        }
    }
}