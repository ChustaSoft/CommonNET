using ChustaSoft.Common.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ChustaSoft.Common.Wpf.UnitTest
{
    public class DefaultVisibilityConverterUnitTest
    {

        private DefaultVisibilityConverter _defaultVisibilityConverter;

        [OneTimeSetUp]
        public void Setup()
        {
            _defaultVisibilityConverter = new DefaultVisibilityConverter();
        }

        [Test]
        public void Given_Null_When_Convert_Then_VisibleRetrived()
        {
            var result = _defaultVisibilityConverter.Convert(null, typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [Test]
        public void Given_Object_When_Convert_Then_CollapsedRetrived()
        {
            var result = _defaultVisibilityConverter.Convert(new object(), typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Hidden, result);
        }

    }
}
