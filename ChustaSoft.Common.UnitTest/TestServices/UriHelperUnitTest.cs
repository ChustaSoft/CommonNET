using ChustaSoft.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace ChustaSoft.Common.UnitTest.TestServices
{

    [TestClass]
    [TestCategory(nameof(UriHelper))]
    public class UriHelperUnitTest
    {

        #region Test Cases

        [TestMethod]
        public void Given_UriBuilderAndParam_When_AddParameterInvoked_Then_UriBuilderCreatedWithNewParam()
        {
            var uriBuilder = new UriBuilder("http://www.testapi.com/api");
            var testParam = "TestParam";
            var testData = "TestData";

            var generatedUri = uriBuilder.AddParameter(testParam, testData).Uri;

            Assert.IsTrue(generatedUri.ToString().Contains(testParam));
            Assert.IsTrue(generatedUri.ToString().Contains(testData));
        }

        [TestMethod]
        public void Given_UriBuilderAndParamWithSpaces_When_AddParameterInvoked_Then_UriBuilderCreatedWithNewParam()
        {
            var uriBuilder = new UriBuilder("http://www.testapi.com/api");
            var testParam = "TestParam";
            var testData = "Test Data";
            var transformedData = "Test+Data";

            var generatedUri = uriBuilder.AddParameter(testParam, testData).Uri;

            Assert.IsTrue(generatedUri.ToString().Contains(testParam));
            Assert.IsTrue(generatedUri.ToString().Contains(transformedData));
        }

        #endregion

    }
}
