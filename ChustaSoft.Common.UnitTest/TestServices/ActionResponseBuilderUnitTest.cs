using ChustaSoft.Common.Enums;
using ChustaSoft.Common.Exceptions;
using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;


namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    [TestCategory("ActionResponseBuilder")]
    public class ActionResponseBuilderUnitTest
    {

        #region Test Cases

        [TestMethod]
        public void Given_Data_When_ConstructorInvoked_Then_ActionResponseBuilderWithDataRetrived()
        {
            var data = DateTime.Now;

            var actionResponseBuilder = new ActionResponseBuilder<DateTime>(data);
            var builtActionResponse = actionResponseBuilder.Build();

            Assert.AreEqual(data, builtActionResponse.Data);
        }

        [TestMethod]
        public void Given_ActionResponseBuilder_When_SetStatusInvoked_Then_ActionResponseBuilderWithDataAndStatusRetrived()
        {
            var data = DateTime.Now;
            var status = ActionResponseType.Success;
            var builtActionResponse = new ActionResponseBuilder<DateTime>(data)
                .SetStatus(status)
                .Build();

            Assert.AreEqual(data, builtActionResponse.Data);
            Assert.AreEqual(status, builtActionResponse.Flag);
        }

        [TestMethod]
        public void Given_ActionResponseBuilder_When_AddErrorInvokedFromErrorMessage_Then_ActionResponseBuilderWithDataAndErrorsRetrived()
        {
            var data = DateTime.Now;
            var errorMessage = new ErrorMessage(new BusinessException("Test Exception", null));

            var builtActionResponse = new ActionResponseBuilder<DateTime>(data)
                .AddError(errorMessage)
                .Build();

            Assert.AreEqual(data, builtActionResponse.Data);
            Assert.IsTrue(builtActionResponse.Errors.Any());
        }

        [TestMethod]
        public void Given_ActionResponseBuilder_When_AddErrorInvokedFromException_Then_ActionResponseBuilderWithDataAndErrorsRetrived()
        {
            var data = DateTime.Now;
            
            var builtActionResponse = new ActionResponseBuilder<DateTime>(data)
                .AddError(new BusinessException("Test Exception", null))
                .Build();

            Assert.AreEqual(data, builtActionResponse.Data);
            Assert.IsTrue(builtActionResponse.Errors.Any());
        }

        [TestMethod]
        public void Given_ActionResponseBuilder_When_AddErrorInvokedFromErrorTypeAndMessage_Then_ActionResponseBuilderWithDataAndErrorsRetrived()
        {
            var data = DateTime.Now;

            var builtActionResponse = new ActionResponseBuilder<DateTime>(data)
                .AddError(ErrorType.Validation, "Test Validation")
                .Build();

            Assert.AreEqual(data, builtActionResponse.Data);
            Assert.IsTrue(builtActionResponse.Errors.Any());
        }

        [TestMethod]
        public void Given_ActionResponseBuilderAndData_When_AddDataInvoked_Then_ActionResponseBuilderWithDataRetrived()
        {
            var data = DateTime.Now;

            var builtActionResponse = new ActionResponseBuilder<DateTime>()
                .AddData(data)
                .Build();

            Assert.AreEqual(data, builtActionResponse.Data);
        }

        [TestMethod]
        public void Given_ActionResponseBuilder_When_BuildInvokedWithMultipleInfo_Then_ActionResponseRetrived()
        {
            var data = DateTime.Now;
            var status = ActionResponseType.Warning;

            var builtActionResponse = new ActionResponseBuilder<DateTime>()
                .AddData(data)
                .AddError(new BusinessException("Test Exception", null))
                .AddError(new ErrorMessage(new BusinessException("Test Exception", null)))
                .AddError(ErrorType.Validation, "Test Validation")
                .SetStatus(status)
                .Build();

            Assert.AreEqual(data, builtActionResponse.Data);
            Assert.IsTrue(builtActionResponse.Errors.Count() == 3);
            Assert.AreEqual(status, builtActionResponse.Flag);
        }

        #endregion

    }
}
