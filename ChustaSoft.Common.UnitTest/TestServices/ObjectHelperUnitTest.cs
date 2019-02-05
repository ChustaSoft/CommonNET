using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.UnitTest.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    public class ObjectHelperUnitTest
    {

        [TestMethod]
        public void Given_TypeAndPropertyWithDescription_When_GetDescriptionInvoked_Then_DescriptionRetrived()
        {
            var description = typeof(TestClass).GetDescription(nameof(TestClass.KnownDescription));

            Assert.AreEqual("Test description", description);
        }

        [TestMethod]
        public void Given_TypeAndPropertyWithoutDescription_When_GetDescriptionInvoked_Then_NameItselfReturned()
        {
            var description = typeof(TestClass).GetDescription(nameof(TestClass.UnknownDescription));

            Assert.AreEqual(nameof(TestClass.UnknownDescription), description);
        }

        [TestMethod]
        public void Given_TypeAndNull_When_GetDescriptionInvoked_Then_ExceptionThrown()
        {
            Assert.ThrowsException<NullReferenceException>(() => typeof(TestClass).GetDescription(null));
        }

        [TestMethod]
        public void Given_TypeAndWrongString_When_GetDescriptionInvoked_Then_ExceptionThrown()
        {
            Assert.ThrowsException<InvalidOperationException>(() => typeof(TestClass).GetDescription(string.Empty));
        }

    }

}
