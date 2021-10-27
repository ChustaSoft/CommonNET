using ChustaSoft.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    [TestCategory(nameof(CollectionsHelper))]
    public class CollectionsHelperUnitTest
    {

        #region Test Cases

        [TestMethod]
        public void Given_IEnumerableWith20Elements_When_PaginateWithSize10AndNumber0_Then_PaginatedFirstIEnumerableRetrived()
        {
            var pageSize = 10;
            var testCollection = GetTestList(200);

            var paginatedEnumerable = testCollection.Paginate(pageSize);

            Assert.IsTrue(paginatedEnumerable.Count() == pageSize);
            Assert.IsTrue(paginatedEnumerable.Any(x => x.Item1 == 1));
        }

        [TestMethod]
        public void Given_IEnumerableWith20Elements_When_PaginateWithSize10AndNumber1_Then_PaginatedSecondIEnumerableRetrived()
        {
            int pageSize = 10, pageNumber = 1;
            var testCollection = GetTestList(200);

            var paginatedEnumerable = testCollection.Paginate(pageSize, pageNumber);

            Assert.IsTrue(paginatedEnumerable.Count() == pageSize);
            Assert.IsTrue(paginatedEnumerable.Any(x => x.Item1 == 11));
        }

        [TestMethod]
        public void Given_CollectionAndPageSize_When_ToPaginatedListInvoked_Then_PaginationPerformed()
        {
            var pageSize = 10;
            var testCollection = GetTestList(200);

            var paginatedData = testCollection.ToPaginatedList(pageSize);

            Assert.IsTrue(paginatedData.Count == pageSize);
            Assert.IsTrue(paginatedData.TotalCount == testCollection.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndPageIndex_When_ToPaginatedListInvoked_Then_PaginationPerformed()
        {
            var pageSize = 10;
            var currentPageIndex = 1;
            var testList = GetTestList(200);

            var paginatedData = testList.ToPaginatedList(pageSize, currentPageIndex);

            Assert.IsTrue(paginatedData.Count == pageSize);
            Assert.IsTrue(!paginatedData.Any(x => x.Item1 == 1));
            Assert.IsTrue(paginatedData.Any(x => x.Item1 == 15));
            Assert.IsTrue(paginatedData.TotalCount == testList.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSize_When_ToPaginatedListInvoked_Then_SamePaginatedCollectionRetrived()
        {
            var pageSize = 10;
            var testList = GetTestList(5);

            var paginatedData = testList.ToPaginatedList(pageSize);

            Assert.IsTrue(paginatedData.Count == testList.Count);
            Assert.IsTrue(paginatedData.TotalCount == testList.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndCurrentPage_When_ToPaginatedListInvoked_Then_SameCollectionPaginatedRetrived()
        {
            var pageSize = 10;
            var currentPageIndex = 1;
            var testList = GetTestList(5);

            var paginatedData = testList.ToPaginatedList(pageSize, currentPageIndex);

            Assert.IsTrue(paginatedData.Count == testList.Count);
            Assert.IsTrue(paginatedData.TotalCount == testList.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndCurrentPageOnEnd_When_ToPaginatedListInvoked_Then_CollectionReminderPaginatedRetrived()
        {
            var totalSize = 15;
            var pageSize = 10;
            var currentPageIndex = 1;
            var testList = GetTestList(totalSize);

            var paginatedData = testList.ToPaginatedList(pageSize, currentPageIndex);

            Assert.IsTrue(paginatedData.Count == totalSize % pageSize);
            Assert.IsTrue(paginatedData.TotalCount == testList.Count);
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndCurrentPageOverLimitIndex_When_ToPaginatedListInvoked_Then_ExceptionThrowns()
        {
            var pageSize = 10;
            var currentPageIndex = 4;
            var testList = GetTestList(25);

            Assert.ThrowsException<InvalidOperationException>(() => testList.ToPaginatedList(pageSize, currentPageIndex));
        }

        [TestMethod]
        public void Given_CollectionAndPageSizeAndCurrentPageIndexUnderLimit_When_ToPaginatedListInvoked_Then_ExceptionThrown()
        {
            var pageSize = 10;
            var currentPageIndex = -1;
            var testList = GetTestList(25);

            Assert.ThrowsException<InvalidOperationException>(() => testList.ToPaginatedList(pageSize, currentPageIndex));
        }

        [TestMethod]
        public void Given_CollectionSingleElementAndConcurrentBag_When_AddRange_Then_ElementsAdded()
        {
            var concurrentBagExample = new ConcurrentBag<string>();
            var testList1 = new List<string> { "String1", "String2", "String3", "String4" };

            concurrentBagExample.AddRange(testList1);
            concurrentBagExample.Add("TEST");

            Assert.AreEqual(testList1.Count + 1, concurrentBagExample.Count);
        }

        [TestMethod]
        public void Given_TwoCollectionsAndConcurrentBag_When_AddRange_Then_ElementsAdded()
        {
            var concurrentBagExample = new ConcurrentBag<string>();
            var testList1 = new List<string> { "String1", "String2", "String3", "String4" };
            var testList2 = new List<string> { "String5", "String6", "String7", "String8", "String9", "String0" };

            concurrentBagExample.AddRange(testList1);
            concurrentBagExample.AddRange(testList2);

            Assert.AreEqual(testList1.Count + testList2.Count, concurrentBagExample.Count);
        }

        [TestMethod]
        public void Given_MultipleParallelizedCollectionsAndConcurrentBag_When_AddRange_Then_ElementsAdded()
        {
            var concurrentBagExample = new ConcurrentBag<string>();

            Parallel.For(0, 10, i =>
            {
                concurrentBagExample.AddRange(new List<string> { "Test1", "Test2" });
            });

            Assert.AreEqual(10 * 2, concurrentBagExample.Count);
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
