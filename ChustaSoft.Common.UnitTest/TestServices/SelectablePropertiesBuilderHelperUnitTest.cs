using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Models;
using ChustaSoft.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    public class SelectablePropertiesBuilderHelperUnitTest
    {

        public class TestClass
        {
            public string TestPropertyStr { get; set; }
            public int TestPropertyInt { get; set; }
            public IEnumerable<DateTime> TestCollectionDates { get; set; }
        }


        [TestMethod]
        public void Given_Function_WhenSelectPropertyInvoked_ThenISelectablePropertiesBuilderRetrived()
        {
            var testObj = DateTime.Now;

            var testBuilder = testObj.SelectProperty(x => x.Day);

            Assert.AreEqual(testBuilder.Count, 1);
            SelectablePropertiesContext.ResetContext();
        }

        [TestMethod]
        public void Given_Function_WhenThenSelectPropertyInvoked_ThenISelectablePropertiesBuilderRetrived()
        {
            var testBuilder = SelectablePropertiesBuilder<DateTime>
                .GetProperties()
                .SelectProperty(x => x.Day)
                .ThenSelectProperty(x => x.Month);

            Assert.AreEqual(testBuilder.Count, 2);
            SelectablePropertiesContext.ResetContext();
        }

        [TestMethod]
        public void Given_Function_WhenFormatSelectionInvoked_ThenStringFormattedRetrived()
        {
            var propertiesFormatted = SelectablePropertiesBuilder<DateTime>
                .GetProperties()
                .SelectProperty(x => x.Day)
                .ThenSelectProperty(x => x.Month)
                .FormatSelection();

            Assert.IsFalse(string.IsNullOrEmpty(propertiesFormatted));
            Assert.IsTrue(propertiesFormatted.LastIndexOf(',') != propertiesFormatted.Length);
        }

        [TestMethod]
        public void Given_ExternalType_WhenFormatSelectionInvoked_ThenStringFormattedRetrived()
        {
            var propertiesFormatted = SelectablePropertiesBuilder<TestClass>
               .GetProperties()
               .SelectProperty(x => x.TestPropertyStr)
               .ThenSelectProperty(x => x.TestPropertyInt)
               .FormatSelection();

            Assert.IsFalse(string.IsNullOrEmpty(propertiesFormatted));
            Assert.IsTrue(propertiesFormatted.LastIndexOf(',') != propertiesFormatted.Length);
        }

        [TestMethod]
        public void Given_ExternalType_WhenFormatSelectionInvoked_ThenStringFormattedRetrived2()
        {
            var propertiesFormatted = SelectablePropertiesBuilder<TestClass>
               .GetProperties()
               .SelectProperty(x => x.TestPropertyStr)
               .ThenSelectProperty(x => x.TestPropertyInt)
               .ThenSelectFromCollection(x => x.TestCollectionDates)
                    .ThenSelectProperty(x => x.Minute)
               .FormatSelection();

            //Assert.IsFalse(string.IsNullOrEmpty(propertiesFormatted));
            //Assert.IsTrue(propertiesFormatted.LastIndexOf(',') != propertiesFormatted.Length);
        }

    }
}
