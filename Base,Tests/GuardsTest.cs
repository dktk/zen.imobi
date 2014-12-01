using Ploeh.AutoFixture.Xunit;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Base.Tests
{
    public class GuardsTest
    {
        class Tester
        {
            private string _value;

            public Tester(Guid value)
            {

            }

            public Tester(object value)
            {

            }

            public Tester(string value)
            {
                Guard.AgainstNullOrEmpty(value);

                _value = value;
            }
        }

        [Theory]
        [AutoData]
        public void AgainstNullOrEmpty(string value)
        {
            var tester = new Tester(value);

            Assert.NotNull(tester);
        }

        [Theory]
        [AutoData]
        public void AgainstNullOrEmpty_Guid(Guid value)
        {
            var tester = new Tester(value);

            Assert.NotNull(tester);
        }

        [Theory]
        [AutoData]
        public void AgainstNullOrEmpty_Object(object value)
        {
            var tester = new Tester(value);

            Assert.NotNull(tester);
        }

        [Theory]
        [InlineData(null)]
        public void AgainstNullOrEmpty_Throws_When_Nulls_Are_Passed(string value)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var tester = new Tester(value);
            });
        }
    }
}