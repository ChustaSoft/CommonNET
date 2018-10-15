using ChustaSoft.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    [TestCategory("ActionResponseBuilder")]
    public class ActionResponseBuilderHelperUnitTest
    {

        #region Test Cases

        [TestMethod]
        public void Given_ActionResponseBuilderAndData_When_AddElementInvoked_Then_ActionResponseBuilderWithDataRetrived()
        {
            var data = DateTime.Now;

            var builtActionResponse = new ActionResponseBuilder<List<DateTime>>()
                .SetData(new List<DateTime> { data })
                .AddElement(data)
                .Build();

            Assert.IsTrue(builtActionResponse.Data.Count() == 2);
            Assert.IsTrue(builtActionResponse.Data.Any(x => x == data));
        }

        [TestMethod]
        public void Given_ActionResponseBuilderAndCollectionData_When_AddRangeInvoked_Then_ActionResponseBuilderWithDataRetrived()
        {
            var data = new List<DateTime> { DateTime.Now, DateTime.Now };

            var builtActionResponse = new ActionResponseBuilder<List<DateTime>>()
                .SetData(data)
                .AddRange(data)
                .Build();

            Assert.IsTrue(builtActionResponse.Data.Count() == 4);
        }

        [TestMethod]
        public void Given_ActionResponseBuilderAndData_When_AddRangeInvokedFirst_Then_ExceptionThrown()
        {
            Assert.ThrowsException<ArgumentException>(() => new ActionResponseBuilder<List<DateTime>>().AddElement(DateTime.Now));
        }

        [TestMethod]
        public void Given_ActionResponseBuilderAndCollectionData_When_AddRangeInvokedFirst_Then_ExceptionThrown()
        {
            var data = new List<DateTime> { DateTime.Now, DateTime.Now };

            Assert.ThrowsException<ArgumentException>(() => new ActionResponseBuilder<List<DateTime>>().AddRange(data));
        }

        #endregion

    }
}
