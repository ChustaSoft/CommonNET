using System;
using System.ComponentModel;


namespace ChustaSoft.Common.UnitTest.TestHelpers
{
    internal enum TestEnum
    {
        WithoutDescription,

        [Description("1")]
        WithDescription1,

        [Description("2")]
        WithDescription2
    }

    internal enum TestCastEnum 
    { 
        Type1,
        Type2,
        Type3
    }

    internal enum TestEnumCustomAttributes
    {
        [Custom("test-1")]
        Value1,

        Value2,
    }

    internal class TestClass
    {

        public int TestInt { get; set; }

        [Description("Test description")]
        public string KnownDescription { get; set; }

        public string UnknownDescription { get; set; }

    }

    internal class TestClassWithIndexer
    {
        public int TestInt { get; set; }

        public string TestString { get; set; }

        public string this[string key] => string.Empty;
    }

    public class CustomAttribute : Attribute
    {

        public string TestProperty { get; set; }

        public CustomAttribute(string testProperty)
        {
            TestProperty = testProperty;
        }

    }

}
