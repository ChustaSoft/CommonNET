using ChustaSoft.Common.Base;
using ChustaSoft.Common.Builders;
using ChustaSoft.Common.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Net;
using System.Security.Claims;

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
        public void Given_TokenWithUserId_When_GetRequestUserId_Then_UserIdRetrived()
        {
            //Arrange
            const string expectedUserId = "ff85452f-465b-4539-a056-fd516d635df5";
            var testController = CreateTestController(new ControllerContext()
            {
                HttpContext = CreateHttpContextWithAuthrizationHeader(),
            });

            //Act
            var userId = testController.GetRequestUserId();

            //Assert
            Assert.AreEqual(userId, expectedUserId);
        }

        [Test]
        public void Given_TokenWithUserIdInnameidClaim_When_GetRequestUserId_Then_UserIdRetrived()
        {
            //Arrange
            const string expectedUserId = "4c5a0310-8299-4a0b-8eb5-3d9a49a5aa8b";

            var testController = CreateTestController(new ControllerContext()
            {
                HttpContext = CreateHttpContextWithAuthrizationHeader(IdClaimType.Nameid),
            });

            //Act
            var userId = testController.GetRequestUserId();

            //Assert
            Assert.AreEqual(userId, expectedUserId);
        }

        [Test]
        public void Given_TokenWithEmail_When_GetRequestUserEmail_Then_UserEmailRetrived()
        {
            //Arrange
            var testController = CreateTestController(new ControllerContext()
            {
                HttpContext = CreateHttpContextWithAuthrizationHeader(),
            });

            //Act
            var userEmail = testController.GetRequestUserEmail();

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(userEmail));
        }

        [Test]
        public void Given_IdentityWithEmail_When_GetRequestUserEmail_Then_UserEmailRetrived()
        {
            //Arrange
            var testController = CreateTestController(new ControllerContext()
            {
                HttpContext = CreateHttpContextWithIdentity(),
            });

            //Act
            var userEmail = testController.GetRequestUserEmail();

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(userEmail));
        }

        [Test]
        public void Given_WithEmailInUpnClaim_When_GetRequestUserEmail_Then_UserEmailRetrived()
        {
            //Arrange
            var testController = CreateTestController(new ControllerContext()
            {
                HttpContext = CreateHttpContextWithIdentityInUpn(),
            });

            //Act
            var userEmail = testController.GetRequestUserEmail();

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(userEmail));
        }

        [Test]
        public void Given_IdentityWithoutRmail_When_GetRequestUserEmail_With_InvalidClaim_Then_Exception()
        {
            //Arrange
            var testController = CreateTestController(new ControllerContext()
            {
                HttpContext = CreateHttpContextWithoutIdentity(),
            });

            //Act
            TestDelegate act = () => testController.GetRequestUserEmail();

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(act);
        }


        private TestController CreateTestController(ControllerContext controllerContext = null)
        {
            return new TestController(new Mock<ILogger<TestController>>().Object)
            {
                ControllerContext = controllerContext ?? new ControllerContext()
            };
        }

        private DefaultHttpContext CreateHttpContextWithAuthrizationHeader(IdClaimType idClaimType = IdClaimType.Oid)
        {
            var httpContext = new DefaultHttpContext();

            switch (idClaimType) 
            {
                case IdClaimType.Oid:
                    httpContext.Request.Headers["Authorization"] = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Imwzc1EtNTBjQ0g0eEJWWkxIVEd3blNSNzY4MCIsImtpZCI6Imwzc1EtNTBjQ0g0eEJWWkxIVEd3blNSNzY4MCJ9.eyJhdWQiOiJhcGk6Ly9iNjZjYjc5MS01NWY4LTQ4OGMtODFjNC0yNzM2MjJhODVkNWEiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC80NTMxZDk4NC03M2QwLTQ0MzktYTEwNi00YThhNDRkZGI4YzcvIiwiaWF0IjoxNjMzOTM4NDU2LCJuYmYiOjE2MzM5Mzg0NTYsImV4cCI6MTYzMzk0MjM1NiwiYWNyIjoiMSIsImFpbyI6IkFWUUFxLzhUQUFBQXk3akw3UE0wWGs4azVuSXhMV0ZiRGhoeFIrQ1hORm9BODQvQUVDT1hCVXRzL2l1TTNIQTI0RDl1V25pYVlRa3VzZGRoS2ROdEYyWDZwdnVQRDZoMEVmN3JBTk9SZGJlWG5UWDM2UmZ6cU1zPSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiI2OTI4NDNmOS00N2M2LTQwMTctYjYyNS1mYjJiOTBkZTE1ZDgiLCJhcHBpZGFjciI6IjEiLCJlbWFpbCI6Impvc2UuZWlndXJlbkBjb3RlY25hLmVzIiwiZmFtaWx5X25hbWUiOiJFaWd1cmVuIiwiZ2l2ZW5fbmFtZSI6Ikpvc2UiLCJpcGFkZHIiOiI5MC4xNzMuMTQ3LjEwOCIsIm5hbWUiOiJFaWd1cmVuIEpvc2UiLCJvaWQiOiJmZjg1NDUyZi00NjViLTQ1MzktYTA1Ni1mZDUxNmQ2MzVkZjUiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtNjA2NzQ3MTQ1LTE5NTc5OTQ0ODgtODM5NTIyMTE1LTI4NzM3IiwicmgiOiIwLkFZRUFoTmt4UmRCek9VU2hCa3FLUk4yNHhfbERLR25HUnhkQXRpWDdLNURlRmRpQkFDSS4iLCJzY3AiOiJwYXJraW5nX2FwaV9hY2Nlc3MiLCJzaWQiOiJlOTU3YzEzOC00NmU4LTQwMjAtYjI3My1mM2Q0N2RiNTFjNjYiLCJzdWIiOiJSQkpLWlFPTDRuQjZCME5pSGVHblFlVFpVWkVNUTJTN01PMnpUYU1ISXpjIiwidGlkIjoiNDUzMWQ5ODQtNzNkMC00NDM5LWExMDYtNGE4YTQ0ZGRiOGM3IiwidW5pcXVlX25hbWUiOiJqb3NlLmVpZ3VyZW5AY290ZWNuYS5lcyIsInVwbiI6Impvc2UuZWlndXJlbkBjb3RlY25hLmVzIiwidXRpIjoiS2V6SWhjTkM5a2VILURiaTRPN0lBQSIsInZlciI6IjEuMCJ9.MIfNYBb1_--GgHZM7-9JFd6mUjhU_Os-3CU8HToFn8rJc8IzFS0BgfJMLTn730YVYNYSfwFr8JGt5ISHdHkorFJdAi7jY6n_hESCK0uyC1jcXjiKgeMOP-8OMZ2OXGHbu_-e0Qb4ujUGrdWygSKfyv6kWH5-weLZjWv8I2mN0cdmotbNDbygyI6GJa9kPEEoQNkzxxLu-9yzpk7HKIV9BXL3KV1-XErRoDhKFJiaxlQooKTlxzjqaGoUVu7gTKdXHmOXJBdObhJIaaKBVcaW66iYM391LlVLK2hIahJ6YHXoyiwmySWBObHyP0mmfNRv6hrst_l77y8ax71DtSNe8Q";
                    break;
                case IdClaimType.Nameid:
                    httpContext.Request.Headers["Authorization"] = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3RAbWFpbC5jb20iLCJuYW1laWQiOiI0YzVhMDMxMC04Mjk5LTRhMGItOGViNS0zZDlhNDlhNWFhOGIiLCJlbWFpbCI6InRlc3RAbWFpbC5jb20iLCJyb2xlIjpbIlN5c3RlbSBBZG1pbiIsIlN1cGVyIEFkbWluIl0sImN1bHR1cmUiOiJlbi1VSyIsInN1YiI6InRlc3RAbWFpbC5jb20iLCJqdGkiOiIxYWJhNmU5NS1kNTlmLTRlM2QtODBmMi1kODIxMTRjMWY2NDQiLCJhdWQiOiJjb3RlY25hLmVzIiwiaXNzIjoiY290ZWNuYS5lcyIsIm5iZiI6MTY4MjQ5MDQ3OSwiZXhwIjoxNjgzMDk1Mjc5LCJpYXQiOjE2ODI0OTA0Nzl9.JLidtcuqp_VDi_paX05HRT68ekawGtZTvC4Mjw3IZcg";
                    break;
            }

            return httpContext;
        }

        private DefaultHttpContext CreateHttpContextWithIdentity()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "Name"),
                new Claim(ClaimTypes.NameIdentifier, Guid.Parse("0bd1cd81-f260-4005-ad6e-3c6e8b9ef6f9").ToString()),
                new Claim(ClaimTypes.Email, "mail@test.com")
            }, "MockedIdentity"));

            return new DefaultHttpContext() { User = user };
        }

        private DefaultHttpContext CreateHttpContextWithoutIdentity()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "Name"),
                new Claim(ClaimTypes.NameIdentifier, Guid.Parse("0bd1cd81-f260-4005-ad6e-3c6e8b9ef6f9").ToString())               
            }, "MockedIdentity"));

            return new DefaultHttpContext() { User = user };
        }

        private DefaultHttpContext CreateHttpContextWithIdentityInUpn()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "Name"),
                new Claim(ClaimTypes.NameIdentifier, Guid.Parse("0bd1cd81-f260-4005-ad6e-3c6e8b9ef6f9").ToString()),
                new Claim("upn", "mail@test.com")
            }, "MockedIdentity"));

            return new DefaultHttpContext() { User = user };
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


    internal enum IdClaimType 
    {
        Oid,
        Nameid
    }
}
