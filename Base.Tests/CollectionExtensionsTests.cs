using Ploeh.AutoFixture.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace Base.Tests
{
    public class CollectionExtensionsTests
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

        [Theory]
        [AutoData]
        public void IsNullOrEmpty(string element)
        {
            IEnumerable<string> nullCollection = null;
            IEnumerable<string> emptyCollection = Enumerable.Empty<string>();
            IEnumerable<string> collection = new[] { element };

            Func<string, bool> predicate = x => x == element + element;
            Assert.True(nullCollection.IsNullOrEmpty());
            Assert.True(emptyCollection.IsNullOrEmpty());
            Assert.False(collection.IsNullOrEmpty());
            Assert.True(collection.IsNullOrEmpty(predicate));
        }

        [Theory]
        [AutoData]
        public void Dictionary_GetOrAdd(string missingKey)
        {
            var dictionary = new Dictionary<string, string>();

            var value = dictionary.GetOrAdd(missingKey);

            Assert.Equal(1, dictionary.Keys.Count);
            Assert.Equal(missingKey, dictionary.Keys.First());
            Assert.Null(value);
        }
    }
}