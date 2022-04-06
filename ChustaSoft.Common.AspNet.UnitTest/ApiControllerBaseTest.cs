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
    public class ApiControllerBaseTest
    {
        [Test]
        public void Given_ExtendedController_When_GetEmptyResponseBuilder_Then_ActionResponseEmptyRetrived()
        {
            var testController = CreateTestController();
            var actionResponseBuilder = testController.Expose_GetEmptyResponseBuilder<DateTime?>();
            var actionResponse = actionResponseBuilder.Build();

            Assert.AreEqual(typeof(ActionResponseBuilder<DateTime?>), actionResponseBuilder.GetType());
            Assert.AreEqual(typeof(ActionResponse<DateTime?>), actionResponse.GetType());
            Assert.IsNull(actionResponse.Data);
            Assert.IsEmpty(actionResponse.Errors);
        }

        [Test]
        public void Given_ActionResponseBuilder_When_Ok_Then_IActionResultRetrived()
        {
            var testController = CreateTestController();
            var actionResponseBuilder = testController.Expose_GetEmptyResponseBuilder<DateTime?>();
            var result = (OkObjectResult)testController.Expose_Ok(actionResponseBuilder);

            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(typeof(ActionResponse<DateTime?>), result.Value.GetType());
            Assert.IsNull(((ActionResponse<DateTime?>)result.Value).Data);
            Assert.IsEmpty(((ActionResponse<DateTime?>)result.Value).Errors);
        }

        [Test]
        public void Given_ActionResponseBuilderAndException_When_Ko_Then_IActionResultRetrived()
        {
            var testController = CreateTestController();
            var actionResponseBuilder = testController.Expose_GetEmptyResponseBuilder<DateTime?>();
            var result = (BadRequestObjectResult)testController.Expose_Ko(actionResponseBuilder, new Exception("Test Exception thrown"));

            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(typeof(ActionResponse<DateTime?>), result.Value.GetType());
            Assert.IsNull(((ActionResponse<DateTime?>)result.Value).Data);
            Assert.IsNotEmpty(((ActionResponse<DateTime?>)result.Value).Errors);
        }

        [Test]
        public void Given_TokenWithUserId_When_GetRequestUserId_Then_UserId()
        {
            //Arrange
            const string expectedUserId = "ff85452f-465b-4539-a056-fd516d635df5";
            var httpContext = CreateHttpContextWithAuthrizationHeader();
            var testController = CreateTestController(new ControllerContext()
            {
                HttpContext = httpContext,
            });

            //Act
            var userId = testController.GetRequestUserId();

            //Assert
            Assert.AreEqual(userId, expectedUserId);
        }

        [Test]
        public void Given_TokenWithUserId_When_GetRequestUserId_With_InvalidClaim_Then_Exception()
        {
            //Arrange
            const string expectedErrorMessage = "User id cannot be null";

            var httpContext = CreateHttpContextWithAuthrizationHeader();
            var testController = CreateTestController(new ControllerContext()
            {
                HttpContext = httpContext,
            });

            //Act
            TestDelegate act = () => testController.GetRequestUserId("NonExistingClaim");

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(act);
            Assert.AreEqual(exception.Message, expectedErrorMessage);
        }

        [Test]
        public void Given_TokenWithEmail_When_GetRequestUserEmail_Then_UserEmailRetrived()
        {
            //Arrange
            var httpContext = CreateHttpContextWithAuthrizationHeader();
            var testController = CreateTestController(new ControllerContext()
            {
                HttpContext = httpContext,
            });

            //Act
            var userEmail = testController.GetRequestUserEmail();

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(userEmail));
        }

        private TestController CreateTestController(ControllerContext controllerContext = null)
        {
            return new TestController(new Mock<ILogger<TestController>>().Object)
            {
                ControllerContext = controllerContext ?? new ControllerContext()
            };
        }

        private Microsoft.AspNetCore.Http.DefaultHttpContext CreateHttpContextWithAuthrizationHeader()
        {
            var httpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext();
            httpContext.Request.Headers["Authorization"] = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Imwzc1EtNTBjQ0g0eEJWWkxIVEd3blNSNzY4MCIsImtpZCI6Imwzc1EtNTBjQ0g0eEJWWkxIVEd3blNSNzY4MCJ9.eyJhdWQiOiJhcGk6Ly9iNjZjYjc5MS01NWY4LTQ4OGMtODFjNC0yNzM2MjJhODVkNWEiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC80NTMxZDk4NC03M2QwLTQ0MzktYTEwNi00YThhNDRkZGI4YzcvIiwiaWF0IjoxNjMzOTM4NDU2LCJuYmYiOjE2MzM5Mzg0NTYsImV4cCI6MTYzMzk0MjM1NiwiYWNyIjoiMSIsImFpbyI6IkFWUUFxLzhUQUFBQXk3akw3UE0wWGs4azVuSXhMV0ZiRGhoeFIrQ1hORm9BODQvQUVDT1hCVXRzL2l1TTNIQTI0RDl1V25pYVlRa3VzZGRoS2ROdEYyWDZwdnVQRDZoMEVmN3JBTk9SZGJlWG5UWDM2UmZ6cU1zPSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiI2OTI4NDNmOS00N2M2LTQwMTctYjYyNS1mYjJiOTBkZTE1ZDgiLCJhcHBpZGFjciI6IjEiLCJlbWFpbCI6Impvc2UuZWlndXJlbkBjb3RlY25hLmVzIiwiZmFtaWx5X25hbWUiOiJFaWd1cmVuIiwiZ2l2ZW5fbmFtZSI6Ikpvc2UiLCJpcGFkZHIiOiI5MC4xNzMuMTQ3LjEwOCIsIm5hbWUiOiJFaWd1cmVuIEpvc2UiLCJvaWQiOiJmZjg1NDUyZi00NjViLTQ1MzktYTA1Ni1mZDUxNmQ2MzVkZjUiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtNjA2NzQ3MTQ1LTE5NTc5OTQ0ODgtODM5NTIyMTE1LTI4NzM3IiwicmgiOiIwLkFZRUFoTmt4UmRCek9VU2hCa3FLUk4yNHhfbERLR25HUnhkQXRpWDdLNURlRmRpQkFDSS4iLCJzY3AiOiJwYXJraW5nX2FwaV9hY2Nlc3MiLCJzaWQiOiJlOTU3YzEzOC00NmU4LTQwMjAtYjI3My1mM2Q0N2RiNTFjNjYiLCJzdWIiOiJSQkpLWlFPTDRuQjZCME5pSGVHblFlVFpVWkVNUTJTN01PMnpUYU1ISXpjIiwidGlkIjoiNDUzMWQ5ODQtNzNkMC00NDM5LWExMDYtNGE4YTQ0ZGRiOGM3IiwidW5pcXVlX25hbWUiOiJqb3NlLmVpZ3VyZW5AY290ZWNuYS5lcyIsInVwbiI6Impvc2UuZWlndXJlbkBjb3RlY25hLmVzIiwidXRpIjoiS2V6SWhjTkM5a2VILURiaTRPN0lBQSIsInZlciI6IjEuMCJ9.MIfNYBb1_--GgHZM7-9JFd6mUjhU_Os-3CU8HToFn8rJc8IzFS0BgfJMLTn730YVYNYSfwFr8JGt5ISHdHkorFJdAi7jY6n_hESCK0uyC1jcXjiKgeMOP-8OMZ2OXGHbu_-e0Qb4ujUGrdWygSKfyv6kWH5-weLZjWv8I2mN0cdmotbNDbygyI6GJa9kPEEoQNkzxxLu-9yzpk7HKIV9BXL3KV1-XErRoDhKFJiaxlQooKTlxzjqaGoUVu7gTKdXHmOXJBdObhJIaaKBVcaW66iYM391LlVLK2hIahJ6YHXoyiwmySWBObHyP0mmfNRv6hrst_l77y8ax71DtSNe8Q";

            return httpContext;
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