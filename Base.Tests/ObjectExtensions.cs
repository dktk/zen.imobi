﻿using Ploeh.AutoFixture.Xunit;
using System;
using System.Linq;
using System.Collections.Generic;
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

        [Theory]
        [AutoData]
        public void Match_ErrorBranch(string value)
        {
            var errorResult = 0;
            var successResult = 0;

            value.Match(
                _ => { return value != "abc"; },
                _ => { errorResult = 1; },
                _ => { successResult = 1; });

            Assert.Equal(1, errorResult);
            Assert.Equal(0, successResult);
        }

        [Theory]
        [AutoData]
        public void Match_SuccessBranch(string value)
        {
            var errorResult = 0;
            var successResult = 0;

            value.Match(
                _ => { return value == "abc"; },
                _ => { errorResult = 1; },
                _ => { successResult = 1; });

            Assert.Equal(0, errorResult);
            Assert.Equal(1, successResult);
        }

        [Theory]
        [AutoData]
        public void Match_OnCollectionInstance(string exceptionMessage)
        {
            var numberOfSuccessCalls = 0;

            new [] { Guid.NewGuid(), Guid.NewGuid() }
                .Match<IEnumerable<Guid>, ApplicationException>(
                    _ => _.IsNull(),

                    exceptionMessage,

                    _ =>
                    {
                        numberOfSuccessCalls++;
                    }
                );

            Assert.Equal(1, numberOfSuccessCalls);
        }
    }
}