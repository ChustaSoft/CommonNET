using ChustaSoft.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    public class DateTimeHelperUnitTest
    {

        [TestMethod]
        public void Given_MondayDateTimeAndMondayStarting_When_GetFirstWeekDate_Then_SameDateTimeRetrived() 
        {
            var givenDate = new DateTime(2021, 10, 18);

            var resultDate = givenDate.GetFirstWeekDate();

            Assert.AreEqual(resultDate, givenDate);
        }

        [TestMethod]
        public void Given_MondayDateTimeAndSundayStarting_When_GetFirstWeekDate_Then_PreviousSundayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 18);

            var resultDate = givenDate.GetFirstWeekDate(Enums.WeekCalendarType.SundayFirst);

            Assert.AreEqual(resultDate, givenDate.AddDays(-1));
        }

        [TestMethod]
        public void Given_TuesdayDateTimeAndMondayStarting_When_GetFirstWeekDate_Then_PreviousMondayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 19);

            var resultDate = givenDate.GetFirstWeekDate();

            Assert.AreEqual(resultDate, givenDate.AddDays(-1));
        }

        [TestMethod]
        public void Given_FridayDateTimeAndMondayStarting_When_GetFirstWeekDate_Then_PreviousMondayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 22);
            var expectedDate = new DateTime(2021, 10, 18);

            var resultDate = givenDate.GetFirstWeekDate();

            Assert.AreEqual(resultDate, expectedDate);
        }


        [TestMethod]
        public void Given_FridayDateTimeAndSundayStarting_When_GetFirstWeekDate_Then_PreviousSundayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 22);
            var expectedDate = new DateTime(2021, 10, 17);

            var resultDate = givenDate.GetFirstWeekDate(Enums.WeekCalendarType.SundayFirst);

            Assert.AreEqual(resultDate, expectedDate);
        }

        [TestMethod]
        public void Given_SundayDateTimeAndSundayStarting_When_GetFirstWeekDate_Then_SameSundayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 17);
            var expectedDate = new DateTime(2021, 10, 17);

            var resultDate = givenDate.GetFirstWeekDate(Enums.WeekCalendarType.SundayFirst);

            Assert.AreEqual(resultDate, expectedDate);
        }

        [TestMethod]
        public void Given_SundayDateTimeAndMondayStarting_When_GetFirstWeekDate_Then_PreviousMondayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 24);
            var expectedDate = new DateTime(2021, 10, 18);

            var resultDate = givenDate.GetFirstWeekDate();

            Assert.AreEqual(resultDate, expectedDate);
        }

        [TestMethod]
        public void Given_SaturdayDateTimeAndSundayStarting_When_GetFirstWeekDate_Then_PreviousSundayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 23);
            var expectedDate = new DateTime(2021, 10, 17);

            var resultDate = givenDate.GetFirstWeekDate(Enums.WeekCalendarType.SundayFirst);

            Assert.AreEqual(resultDate, expectedDate);
        }

        [TestMethod]
        public void Given_MondayDateTimeAndMondayStarting_When_GetLastWeekDate_Then_NextSundayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 18);
            var expectedDate = new DateTime(2021, 10, 24);

            var resultDate = givenDate.GetLastWeekDate();

            Assert.AreEqual(resultDate, expectedDate);
        }

        [TestMethod]
        public void Given_SundayDateTimeAndMondayStarting_When_GetLastWeekDate_Then_SameSundayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 24);
            var expectedDate = new DateTime(2021, 10, 24);

            var resultDate = givenDate.GetLastWeekDate();

            Assert.AreEqual(resultDate, expectedDate);
        }

        [TestMethod]
        public void Given_WednesdayDateTimeAndMondayStarting_When_GetLastWeekDate_Then_NextSundayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 20);
            var expectedDate = new DateTime(2021, 10, 24);

            var resultDate = givenDate.GetLastWeekDate();

            Assert.AreEqual(resultDate, expectedDate);
        }


        [TestMethod]
        public void Given_MondayDateTimeAndSundayStarting_When_GetLastWeekDate_Then_NextSaturdayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 18);
            var expectedDate = new DateTime(2021, 10, 23);

            var resultDate = givenDate.GetLastWeekDate(Enums.WeekCalendarType.SundayFirst);

            Assert.AreEqual(resultDate, expectedDate);
        }

        [TestMethod]
        public void Given_SundayDateTimeAndSundayStarting_When_GetLastWeekDate_Then_NextSaturdayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 17);
            var expectedDate = new DateTime(2021, 10, 23);

            var resultDate = givenDate.GetLastWeekDate(Enums.WeekCalendarType.SundayFirst);

            Assert.AreEqual(resultDate, expectedDate);
        }

        [TestMethod]
        public void Given_SaturdayDateTimeAndSundayStarting_When_GetLastWeekDate_Then_SameSaturdayRetrived()
        {
            var givenDate = new DateTime(2021, 10, 23);
            var expectedDate = new DateTime(2021, 10, 23);

            var resultDate = givenDate.GetLastWeekDate(Enums.WeekCalendarType.SundayFirst);

            Assert.AreEqual(resultDate, expectedDate);
        }

    }
}
