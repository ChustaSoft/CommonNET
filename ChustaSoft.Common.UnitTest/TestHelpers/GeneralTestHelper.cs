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

    internal class TestClass
    {

        public int TestInt { get; set; }

        [System.ComponentModel.Description("Test description")]
        public string KnownDescription { get; set; }

        public string UnknownDescription { get; set; }

    }

    internal class TestClassWithIndexer
    {
        public int TestInt { get; set; }

        public string TestString { get; set; }

        public string this[string key] { get => string.Empty; }
    }

}
