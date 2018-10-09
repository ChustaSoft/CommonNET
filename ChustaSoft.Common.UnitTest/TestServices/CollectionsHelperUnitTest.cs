using ChustaSoft.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    [TestCategory(nameof(CollectionsHelper))]
    public class CollectionsHelperUnitTest
    {

        #region Test Cases

        [TestMethod]
        public void Given_CollectionAndPageSize_When_PaginateInvoked_Then_PaginationPerformed()
        {
            var pageSize = 10;
            var testCollection = GetTestList(200);

            var paginatedData = testCollection.Paginate(pageSize);

            Assert.IsTrue(paginatedData.Count == pageSize);
            Assert.IsTrue(paginatedData.TotalCount == testCollection.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndPageIndex_When_PaginateInvoked_Then_PaginationPerformed()
        {
            var pageSize = 10;
            var currentPageIndex = 1;
            var testList = GetTestList(200);

            var paginatedData = testList.Paginate(pageSize, currentPageIndex);

            Assert.IsTrue(paginatedData.Count == pageSize);
            Assert.IsTrue(!paginatedData.Any(x => x.Item1 == 1));
            Assert.IsTrue(paginatedData.Any(x => x.Item1 == 15));
            Assert.IsTrue(paginatedData.TotalCount == testList.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSize_When_PaginateInvoked_Then_SamePaginatedCollectionRetrived()
        {
            var pageSize = 10;
            var testList = GetTestList(5);

            var paginatedData = testList.Paginate(pageSize);

            Assert.IsTrue(paginatedData.Count == testList.Count);
            Assert.IsTrue(paginatedData.TotalCount == testList.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndCurrentPage_When_PaginateInvoked_Then_SameCollectionPaginatedRetrived()
        {
            var pageSize = 10;
            var currentPageIndex = 1;
            var testList = GetTestList(5);

            var paginatedData = testList.Paginate(pageSize, currentPageIndex);

            Assert.IsTrue(paginatedData.Count == testList.Count);
            Assert.IsTrue(paginatedData.TotalCount == testList.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndCurrentPageOnEnd_When_PaginateInvoked_Then_CollectionReminderPaginatedRetrived()
        {
            var totalSize = 15;
            var pageSize = 10;
            var currentPageIndex = 1;
            var testList = GetTestList(totalSize);

            var paginatedData = testList.Paginate(pageSize, currentPageIndex);

            Assert.IsTrue(paginatedData.Count == totalSize % pageSize);
            Assert.IsTrue(paginatedData.TotalCount == testList.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndCurrentPageOverLimitIndex_When_PaginateInvoked_Then_ExceptionThrownS()
        {
            var pageSize = 10;
            var currentPageIndex = 4;
            var testList = GetTestList(25);

            Assert.ThrowsException<InvalidOperationException>(() => testList.Paginate(pageSize, currentPageIndex));
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndCurrentPageIndexUnderLimit_When_PaginateInvoked_Then_ExceptionThrownS()
        {
            var pageSize = 10;
            var currentPageIndex = -1;
            var testList = GetTestList(25);

            Assert.ThrowsException<InvalidOperationException>(() => testList.Paginate(pageSize, currentPageIndex));
        }

        #endregion


        #region Private methods

        private static List<Tuple<int, string>> GetTestList(int size)
        {
            var mockedList = new List<Tuple<int, string>>();

            for (var i = 1; i <= size; i++)
                mockedList.Add(new Tuple<int, string>(i, "TestObject" + i));

            return mockedList;
        }

        #endregion
    }
}
