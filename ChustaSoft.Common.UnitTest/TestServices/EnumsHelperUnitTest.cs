﻿using ChustaSoft.Common.Exceptions;
using ChustaSoft.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static ChustaSoft.Common.UnitTest.TestHelpers.EnumTestHelper;

namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    [TestCategory(nameof(EnumsHelper))]
    public class EnumsHelperUnitTest
    {
        
        #region Test Cases

        [TestMethod]
        public void Given_KnownEnum_When_GetDescriptionInvoked_Then_DescriptionStringRetrived()
        {
            var enumType = TestEnum.WithDescription1;

            var enumDescription = enumType.GetDescription();

            Assert.IsNotNull(enumDescription);
            Assert.AreNotEqual(enumType.ToString(), enumDescription);
        }

        [TestMethod]
        public void Given_KnownEnum_When_GetDescriptionInvoked_Then_ToStringRetrived()
        {
            var enumType = TestEnum.WithoutDescription;

            var enumDescription = enumType.GetDescription();

            Assert.IsNotNull(enumDescription);
            Assert.AreEqual(enumType.ToString(), enumDescription);
        }

        [TestMethod]
        public void Given_KnownDescription_When_GetByDescriptionInvoked_Then_EnumRetrived()
        {
            var enumType = TestEnum.WithoutDescription;
            var enumDescription = enumType.GetDescription();

            var enumTypeRetrived = EnumsHelper.GetByDescription<TestEnum>(enumDescription);

            Assert.AreEqual(enumType, enumTypeRetrived);
        }

        [TestMethod]
        public void Given_UnknownDescription_When_GetByDescriptionInvoked_Then_ExceptionThrown()
        {
            var description = "XXX";

            Assert.ThrowsException<EnumNotFoundException>(() => EnumsHelper.GetByDescription<TestEnum>(description));
        }

        [TestMethod]
        public void Given_WrongType_When_GetByDescriptionInvoked_Then_ExceptionThrown()
        {
            var description = "XXX";

            Assert.ThrowsException<ArgumentException>(() => EnumsHelper.GetByDescription<DateTime>(description));
        }

        [TestMethod]
        public void Given_KnownString_When_GetByStringInvoked_Then_EnumRetrived()
        {
            var enumType = TestEnum.WithDescription1;
            var enumStr = enumType.ToString();
            
            var enumTypeRetrived = EnumsHelper.GetByString<TestEnum>(enumStr);

            Assert.AreEqual(enumType, enumTypeRetrived);
        }

        [TestMethod]
        public void Given_UnknownString_When_GetByStringInvoked_Then_ExceptionThrown()
        {
            var description = "XXX";

            Assert.ThrowsException<ArgumentException>(() => EnumsHelper.GetByString<TestEnum>(description));
        }

        [TestMethod]
        public void Given_WrongType_When_GetByStringInvoked_Then_ExceptionThrown()
        {
            var description = "XXX";

            Assert.ThrowsException<ArgumentException>(() => EnumsHelper.GetByString<DateTime>(description));
        }

        [TestMethod]
        public void Given_KnownEnumType_When_GetEnumListInvoked_Then_EnumListRetrived()
        {
            var enumList = EnumsHelper.GetEnumList<TestEnum>();

            Assert.AreEqual(enumList.Count(), 3);
        }

        [TestMethod]
        public void Given_WrongEnumType_When_GetEnumListInvoked_Then_ExceptionThrown()
        {
            Assert.ThrowsException<ArgumentException>(() => EnumsHelper.GetEnumList<DateTime>());
        }

        [TestMethod]
        public void Given_KnownEnumType_When_GetEnumDictionaryInvoked_Then_EnumListRetrived()
        {
            var enumList = EnumsHelper.GetEnumDictionary<TestEnum>();

            Assert.AreEqual(enumList.Count(), 3);
        }

        [TestMethod]
        public void Given_WrongEnumType_When_GetEnumDictionaryInvoked_Then_ExceptionThrown()
        {
            Assert.ThrowsException<ArgumentException>(() => EnumsHelper.GetEnumDictionary<DateTime>());
        }

        #endregion

    }
}
