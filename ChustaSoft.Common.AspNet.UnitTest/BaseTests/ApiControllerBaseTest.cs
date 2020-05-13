using ChustaSoft.Common.Base;
using ChustaSoft.Common.Builders;
using ChustaSoft.Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Net;

namespace ChustaSoft.Common.AspNet.UnitTest
{
    public class Tests
    {

        private TestController _testControllerBase;


        [OneTimeSetUp]
        public void Setup()
        {
            var mockedLogger = new Mock<ILogger<TestController>>();

            _testControllerBase = new TestController(mockedLogger.Object);
        }


        [Test]
        public void Given_ExtendedController_When_GetEmptyResponseBuilder_Then_ActionResponseEmptyRetrived()
        {
            var actionResponseBuilder = _testControllerBase.Expose_GetEmptyResponseBuilder<DateTime?>();
            var actionResponse = actionResponseBuilder.Build();

            Assert.AreEqual(typeof(ActionResponseBuilder<DateTime?>), actionResponseBuilder.GetType());
            Assert.AreEqual(typeof(ActionResponse<DateTime?>), actionResponse.GetType());
            Assert.IsNull(actionResponse.Data);
            Assert.IsEmpty(actionResponse.Errors);
        }

        [Test]
        public void Given_ActionResponseBuilder_When_Ok_Then_IActionResultRetrived() 
        {
            var actionResponseBuilder = _testControllerBase.Expose_GetEmptyResponseBuilder<DateTime?>();
            var result = (OkObjectResult) _testControllerBase.Expose_Ok(actionResponseBuilder);

            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(typeof(ActionResponse<DateTime?>), result.Value.GetType());
            Assert.IsNull(((ActionResponse<DateTime?>)result.Value).Data);
            Assert.IsEmpty(((ActionResponse<DateTime?>)result.Value).Errors);
        }

        [Test]
        public void Given_ActionResponseBuilderAndException_When_Ko_Then_IActionResultRetrived()
        {
            var actionResponseBuilder = _testControllerBase.Expose_GetEmptyResponseBuilder<DateTime?>();
            var result = (BadRequestObjectResult)_testControllerBase.Expose_Ko(actionResponseBuilder, new Exception("Test Exception thrown"));

            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(typeof(ActionResponse<DateTime?>), result.Value.GetType());
            Assert.IsNull(((ActionResponse<DateTime?>)result.Value).Data);
            Assert.IsNotEmpty(((ActionResponse<DateTime?>)result.Value).Errors);
        }


        public class TestController : ApiControllerBase<TestController>
        {
            public TestController(ILogger<TestController> logger) : base(logger) { }


            internal ActionResponseBuilder<T> Expose_GetEmptyResponseBuilder<T>() 
                => GetEmptyResponseBuilder<T>();
            internal IActionResult Expose_Ok<T>(ActionResponseBuilder<T> actionResponseBuilder) 
                => Ok(actionResponseBuilder);
            internal IActionResult Expose_Ko<T>(ActionResponseBuilder<T> actionResponseBuilder, Exception exception) 
                => Ko(actionResponseBuilder, exception);

        }

    }
}