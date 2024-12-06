using ChustaSoft.Common.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChustaSoft.Common.Wpf.UnitTest
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
            Assert.That(receivedEvents.Count != 0, Is.True);
            Assert.That(receivedEvents.Any(x => x == nameof(TestViewModel.Model)), Is.True);
        }



        private class TestViewModel : ViewModelBase<DateTime>
        {
            public TestViewModel() : base() { }
        }
    }
}
