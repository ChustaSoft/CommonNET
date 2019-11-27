using ChustaSoft.Common.Exceptions;
using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.UnitTest.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;


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

        [TestMethod]
        public void Given_EnumTypeWithCustomAttribute_When_GetAtributes_Then_CustomAttributeRetrived()
        {
            var enumType = TestEnumCustomAttributes.Value1;
            var enumAttr = enumType.GetAttributes<CustomAttribute>();

            Assert.IsFalse(string.IsNullOrEmpty(enumAttr.TestProperty));
            Assert.AreEqual(typeof(CustomAttribute), enumAttr.GetType());
        }

        [TestMethod]
        public void Given_EnumTypeWithoutCustomAttribute_When_GetAtributes_Then_NullRetrived()
        {
            var enumType = TestEnumCustomAttributes.Value2;
            var enumAttr = enumType.GetAttributes<CustomAttribute>();

            Assert.IsNull(enumAttr);
        }

        #endregion

    }
}
