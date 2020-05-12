using ChustaSoft.Common.Helpers;
using NUnit.Framework;
using System.Globalization;
using System.Windows;

namespace ChustaSoft.Common.Wpf.UnitTest
{
    public class VisibilityConverterUnitTest
    {

        private VisibilityConverter _visibilityConverter;

        [OneTimeSetUp]
        public void Setup()
        {
            _visibilityConverter = new VisibilityConverter();
        }

        [Test]
        public void Given_True_When_Convert_Then_VisibleRetrived()
        {
            var result = _visibilityConverter.Convert(true, typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [Test]
        public void Given_False_When_Convert_Then_CollapsedRetrived()
        {
            var result = _visibilityConverter.Convert(false, typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Collapsed, result);
        }

    }
}