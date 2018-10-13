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

        [TestMethod]
        public void Given_UriBuilderAndPartWithoutBackslash_When_AddPartInvoked_Then_PartAddedToUriBuilder()
        {
            var uriBuilder = new UriBuilder("http://www.testapi.com/api");
            var testPart = "test";

            var generatedUri = uriBuilder.AddPathPart(testPart).Uri;

            Assert.IsTrue(generatedUri.ToString().Contains(testPart));
        }

        [TestMethod]
        public void Given_UriBuilderAndPartWithBackslash_When_AddPartInvoked_Then_PartAddedToUriBuilder()
        {
            var uriBuilder = new UriBuilder("http://www.testapi.com/api");
            var testPart = "/test";

            var generatedUri = uriBuilder.AddPathPart(testPart).Uri;

            Assert.IsTrue(generatedUri.ToString().Contains(testPart));
        }

        [TestMethod]
        public void Given_MultpleData_When_UriIsBuilding_Then_UriRetrived()
        {
            string pathPart = "test", paramName = "param", paramValue = "value";

            var generatedUri = new UriBuilder("https://api.testapi.io/")
                .AddPathPart(pathPart)
                .AddParameter(paramName, paramValue)
                .Uri;

            Assert.IsNotNull(generatedUri);
            Assert.IsTrue(generatedUri.ToString().Contains(pathPart));
            Assert.IsTrue(generatedUri.ToString().Contains(paramName));
            Assert.IsTrue(generatedUri.ToString().Contains(paramValue));
        }

        #endregion

    }
}
