using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Base;

namespace Base.Tests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void IsNullOrEmpty()
        {
            string nullString = null;
            string emptyString = string.Empty;

            Assert.IsTrue(nullString.IsNullOrEmpty());
            Assert.IsTrue(emptyString.IsNullOrEmpty());
        }

        [TestMethod]
        public void IsNotNullOrEmpty()
        {
            string value = "string";

            Assert.IsTrue(value.IsNotNullOrEmpty());
        }
    }
}