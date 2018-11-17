using ChustaSoft.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    [TestCategory("ActionResponseBuilder")]
    public class StringHelperUnitTest
    {

        [TestMethod]
        public void Given_NullString_When_ToUpperCamelCaseInvoked_Then_ExceptionThrown()
        {
            string text = null;

            Assert.ThrowsException<ArgumentException>(() => text.ToUpperCamelCase());
        }
        
        [TestMethod]
        public void Given_EmptyString_When_ToUpperCamelCaseInvoked_Then_ExceptionThrown()
        {
            string text = string.Empty;

            Assert.ThrowsException<ArgumentException>(() => text.ToUpperCamelCase());
        }

        [TestMethod]
        public void Given_RegularUpperString_When_ToUpperCamelCaseInvoked_Then_UpperCamelCaseRetrived()
        {
            string text = "HELLO";
            string expectedResult = "Hello";

            var retrivedResult = text.ToUpperCamelCase();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_RegularString_When_ToUpperCamelCaseInvoked_Then_UpperCamelCaseRetrived()
        {
            string text = "Hello";
            string expectedResult = "Hello";

            var retrivedResult = text.ToUpperCamelCase();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_RevertedString_When_ToUpperCamelCaseInvoked_Then_UpperCamelCaseRetrived()
        {
            string text = "hELLO";
            string expectedResult = "Hello";

            var retrivedResult = text.ToUpperCamelCase();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_SingleCharString_When_ToUpperCamelCaseInvoked_Then_UpperCamelCaseRetrived()
        {
            string text = "h";
            string expectedResult = "H";

            var retrivedResult = text.ToUpperCamelCase();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_NullString_When_FirstToUpperInvoked_Then_ExceptionThrown()
        {
            string text = null;

            Assert.ThrowsException<ArgumentException>(() => text.FirstToUpper());
        }

        [TestMethod]
        public void Given_EmptyString_When_FirstToUpperInvoked_Then_ExceptionThrown()
        {
            string text = string.Empty;

            Assert.ThrowsException<ArgumentException>(() => text.FirstToUpper());
        }

        [TestMethod]
        public void Given_RegularUpperString_When_FirstToUpperInvoked_Then_UpperCamelCaseRetrived()
        {
            string text = "HELLO";
            string expectedResult = "HELLO";

            var retrivedResult = text.FirstToUpper();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_RegularString_When_FirstToUpperInvoked_Then_UpperCamelCaseRetrived()
        {
            string text = "Hello";
            string expectedResult = "Hello";

            var retrivedResult = text.FirstToUpper();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_RevertedString_When_FirstToUpperInvoked_Then_UpperCamelCaseRetrived()
        {
            string text = "hELLO";
            string expectedResult = "HELLO";

            var retrivedResult = text.FirstToUpper();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_SingleCharString_When_FirstToUpperInvoked_Then_UpperCamelCaseRetrived()
        {
            string text = "h";
            string expectedResult = "H";

            var retrivedResult = text.FirstToUpper();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_NullString_When_FirstToLowerInvoked_Then_ExceptionThrown()
        {
            string text = null;

            Assert.ThrowsException<ArgumentException>(() => text.FirstToLower());
        }

        [TestMethod]
        public void Given_EmptyString_When_FirstToLowerInvoked_Then_ExceptionThrown()
        {
            string text = string.Empty;

            Assert.ThrowsException<ArgumentException>(() => text.FirstToLower());
        }

        [TestMethod]
        public void Given_RegularUpperString_When_FirstToLowerInvoked_Then_LowerCamelCaseRetrived()
        {
            string text = "HELLO";
            string expectedResult = "hELLO";

            var retrivedResult = text.FirstToLower();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_RegularString_When_FirstToLowerInvoked_Then_LowerCamelCaseRetrived()
        {
            string text = "Hello";
            string expectedResult = "hello";

            var retrivedResult = text.FirstToLower();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_RevertedString_When_FirstToLowerInvoked_Then_LowerCamelCaseRetrived()
        {
            string text = "hELLO";
            string expectedResult = "hELLO";

            var retrivedResult = text.FirstToLower();

            Assert.AreEqual(expectedResult, retrivedResult);
        }

        [TestMethod]
        public void Given_SingleCharString_When_FirstToLowerInvoked_Then_LowerCamelCaseRetrived()
        {
            string text = "h";
            string expectedResult = "h";

            var retrivedResult = text.FirstToLower();

            Assert.AreEqual(expectedResult, retrivedResult);
        }


    }
}
