using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.UnitTest.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    public class ReflectionHelperUnitTest
    {

        [TestMethod]
        public void Given_ObjectWithValues_When_GetProperties_Then_PropertyInfoListRetrivedPopulated()
        {
            var testDescription = "Test description";
            var testUnknown = "Unknown description";
            var testInt = 7;

            var testClass = new TestClass { KnownDescription = testDescription, TestInt = testInt, UnknownDescription = testUnknown };

            var properties = testClass.GetProperties();

            Assert.IsTrue(properties.Count() == 3);
            Assert.IsTrue(properties.Any(x => x.Name == nameof(TestClass.TestInt)));
            Assert.IsTrue(properties.Any(x => x.Name == nameof(TestClass.KnownDescription)));
            Assert.IsTrue(properties.Any(x => x.Name == nameof(TestClass.UnknownDescription)));
            Assert.IsTrue(properties.Any(x => x.Name == nameof(TestClass.TestInt)));
            Assert.IsTrue(properties.Any(x => x.Name == nameof(TestClass.KnownDescription)));
            Assert.IsTrue(properties.Any(x => x.Name == nameof(TestClass.UnknownDescription)));
            Assert.AreEqual(properties.First(x => x.Name == nameof(TestClass.KnownDescription)).Value, testDescription);
            Assert.AreEqual(properties.First(x => x.Name == nameof(TestClass.UnknownDescription)).Value, testUnknown);
            Assert.AreEqual(properties.First(x => x.Name == nameof(TestClass.TestInt)).Value, testInt);
            Assert.AreEqual(properties.First(x => x.Name == nameof(TestClass.KnownDescription)).Type, testDescription.GetType());
            Assert.AreEqual(properties.First(x => x.Name == nameof(TestClass.UnknownDescription)).Type, testUnknown.GetType());
            Assert.AreEqual(properties.First(x => x.Name == nameof(TestClass.TestInt)).Type, testInt.GetType());
        }

        [TestMethod]
        public void Given_ObjectWithValues_When_Empty_Then_ObjectPropertiesCleared()
        {
            var testDescription = "Test description";
            var testUnknown = "Unknown description";
            var testInt = 7;

            var testClass = new TestClass { KnownDescription = testDescription, TestInt = testInt, UnknownDescription = testUnknown };

            testClass.Empty();

            Assert.IsTrue(string.IsNullOrEmpty(testClass.KnownDescription));
            Assert.IsTrue(string.IsNullOrEmpty(testClass.UnknownDescription));
            Assert.AreEqual(testClass.TestInt, 0);
        }

        [TestMethod]
        public void Given_ObjectWithValuesAndAvoidedProperty_When_Empty_Then_ObjectPropertiesCleared()
        {
            var testDescription = "Test description";
            var testUnknown = "Unknown description";
            var testInt = 7;

            var testClass = new TestClass { KnownDescription = testDescription, TestInt = testInt, UnknownDescription = testUnknown };

            testClass.Empty(new List<string> { nameof(TestClass.KnownDescription) });

            Assert.AreEqual(testClass.KnownDescription, testDescription);
            Assert.IsTrue(string.IsNullOrEmpty(testClass.UnknownDescription));
            Assert.AreEqual(testClass.TestInt, 0);
        }

    }
}
