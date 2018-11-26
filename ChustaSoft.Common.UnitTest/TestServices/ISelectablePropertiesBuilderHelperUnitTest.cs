using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    public class ISelectablePropertiesBuilderHelperUnitTest
    {

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
            var testObj = DateTime.Now;

            var testBuilder = testObj.SelectProperty(x => x.Day)
                .ThenSelectProperty(x => x.Month);

            Assert.AreEqual(testBuilder.Count, 2);
        }

        [TestMethod]
        public void Given_Function_WhenFormatSelectionInvoked_ThenStringFormattedRetrived()
        {
            var testObj = DateTime.Now;

            var propertiesFormatted = testObj.SelectProperty(x => x.Day)
                .ThenSelectProperty(x => x.Month)
                .FormatSelection();

            Assert.IsFalse(string.IsNullOrEmpty(propertiesFormatted));
            Assert.IsTrue(propertiesFormatted.LastIndexOf(',') != propertiesFormatted.Length);
        }

        [TestMethod]
        public void Given_EmptyISelectablePropertiesBuilder_WhenFormatSelectionInvoked_ThenEmptyStringRetrived()
        {
            var emptyBuilder = new SelectablePropertiesBuilder<DateTime>();

            var propertiesFormatted = emptyBuilder.FormatSelection();

            Assert.AreEqual(string.Empty, propertiesFormatted);
        }

    }
}
