using System.ComponentModel;


namespace ChustaSoft.Common.UnitTest.TestHelpers
{
    public class EnumTestHelper
    {

        public enum TestEnum
        {
            WithoutDescription,

            [Description("1")]
            WithDescription1,

            [Description("2")]
            WithDescription2
        }

    }
}
