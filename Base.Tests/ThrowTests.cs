using Ploeh.AutoFixture.Xunit;
using System;
using Xunit;
using Xunit.Extensions;

namespace Base.Tests
{
    class ThrowTests
    {
        [Theory]
        [InlineData("1, 2, {0}, 4", 1)]
        public void Throw(string message, int arg)
        {
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                Base.Throw.FormattedException<InvalidOperationException>(message, arg);
            });

            Assert.Equal(string.Format(message, arg), exception.Message);
            Assert.IsType<InvalidOperationException>(exception);
        }

        [Theory]
        [AutoData]
        public void Throw_WithCustomException(string message, string extraSpecialValue)
        {
            var exception = Assert.Throws<TestException>(() =>
            {
                Base.Throw.Exception<TestException>(message, extraSpecialValue);
            });

            Assert.Equal(message, exception.Message);
            Assert.Equal(extraSpecialValue, exception.ExtraSpecialValue);
            Assert.IsType<TestException>(exception);
        }
    }

    public class TestException : Exception
    {
        public string ExtraSpecialValue { get; set; }

        public TestException() { }

        public TestException(string extraSpecialValue)
        {
            ExtraSpecialValue = extraSpecialValue;
        }
    }
}