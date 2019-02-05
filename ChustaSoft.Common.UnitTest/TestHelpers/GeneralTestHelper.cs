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

        [System.ComponentModel.Description("Test description")]
        public string KnownDescription { get; set; }

        public string UnknownDescription { get; set; }

    }
}
