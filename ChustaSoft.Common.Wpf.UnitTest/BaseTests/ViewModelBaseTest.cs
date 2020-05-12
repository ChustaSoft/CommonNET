using ChustaSoft.Common.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChustaSoft.Common.Wpf.UnitTest.BaseTests
{
    public class ViewModelBaseTest
    {

        [Test]
        public void Test_ThatMyEventIsRaised()
        {
            var receivedEvents = new List<string>();
            var modelBase = new TestViewModel();

            modelBase.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            modelBase.Model = DateTime.Now;
            Assert.IsTrue(receivedEvents.Any());
            Assert.IsTrue(receivedEvents.Contains(nameof(TestViewModel.Model)));
        }



        private class TestViewModel : ViewModelBase<DateTime> 
        {
            public TestViewModel() : base() { }
        }
    }
}
