using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    public class ISelectablePropertiesBuilderHelperUnitTest
    {

        public class TestClass
        {
            public string TestPropertyStr { get; set; }
            public int TestPropertyInt { get; set; }
        }


        [TestMethod]
        public void Given_Function_WhenSelectPropertyInvoked_ThenISelectablePropertiesBuilderRetrived()
        {
            var testObj = DateTime.Now;

            var testBuilder = testObj.SelectProperty(x => x.Day);

            Assert.AreEqual(testBuilder.Count, 1);
        }

        [TestMethod]
        public void Given_Function_WhenThenSelectPropertyInvoked_ThenISelectablePropertiesBuilderRetrived()
        {
            var testBuilder = SelectablePropertiesBuilder<DateTime>.InitBuilder()
                .SelectProperty(x => x.Day)
                .ThenSelectProperty(x => x.Month);

            Assert.AreEqual(testBuilder.Count, 2);
        }

        [TestMethod]
        public void Given_Function_WhenFormatSelectionInvoked_ThenStringFormattedRetrived()
        {
            var propertiesFormatted = SelectablePropertiesBuilder<DateTime>.InitBuilder()
                .SelectProperty(x => x.Day)
                .ThenSelectProperty(x => x.Month)
                .FormatSelection();

            Assert.IsFalse(string.IsNullOrEmpty(propertiesFormatted));
            Assert.IsTrue(propertiesFormatted.LastIndexOf(',') != propertiesFormatted.Length);
        }

        [TestMethod]
        public void Given_ExternalType_WhenFormatSelectionInvoked_ThenStringFormattedRetrived()
        {
            var propertiesFormatted = SelectablePropertiesBuilder<TestClass>.InitBuilder()
               .SelectProperty(x => x.TestPropertyStr)
               .ThenSelectProperty(x => x.TestPropertyInt)
               .FormatSelection();

            Assert.IsFalse(string.IsNullOrEmpty(propertiesFormatted));
            Assert.IsTrue(propertiesFormatted.LastIndexOf(',') != propertiesFormatted.Length);
        }

    }
}
