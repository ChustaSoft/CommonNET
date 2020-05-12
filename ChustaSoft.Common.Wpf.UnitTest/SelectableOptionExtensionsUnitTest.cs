using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Common.Wpf.UnitTest
{
    public class SelectableOptionExtensionsUnitTest
    {

        [Test]
        public void Given_SelectOptionListWithAllSelectedTrue_When_GetSelected_Then_AllRetrived() 
        {
            var options = new List<SelectableOption>
            {
                new SelectableOption { Name = "Test1", Selected= true },
                new SelectableOption { Name = "Test2", Selected= true },
                new SelectableOption { Name = "Test3", Selected= true }
            };

            var result = options.GetSelected();

            Assert.AreEqual(options.Count(), result.Count());
        }

        [Test]
        public void Given_SelectOptionListWithPartiallSelectedTrue_When_GetSelected_Then_JustSelectedRetrived()
        {
            var options = new List<SelectableOption>
            {
                new SelectableOption { Name = "Test1", Selected= true },
                new SelectableOption { Name = "Test2", Selected= true },
                new SelectableOption { Name = "Test3", Selected= true },
                new SelectableOption { Name = "Test4", Selected= false },
                new SelectableOption { Name = "Test5", Selected= false }
            };

            var result = options.GetSelected();

            Assert.AreEqual(3, result.Count());
            Assert.IsTrue(result.Contains("Test1"));
            Assert.IsTrue(result.Contains("Test2"));
            Assert.IsTrue(result.Contains("Test3"));
        }

        [Test]
        public void Given_SelectOptionListWithNoneSelected_When_GetSelected_Then_EmptyListRetrived()
        {
            var options = new List<SelectableOption>
            {
                new SelectableOption { Name = "Test1", Selected= false },
                new SelectableOption { Name = "Test2", Selected= false },
                new SelectableOption { Name = "Test3", Selected= false },
                new SelectableOption { Name = "Test4", Selected= false },
                new SelectableOption { Name = "Test5", Selected= false }
            };

            var result = options.GetSelected();

            Assert.IsFalse(result.Any());
        }

        [Test]
        public void Given_SelectOptionGenericListWithAllSelectedTrue_When_GetSelected_Then_AllRetrived()
        {
            var options = new List<SelectableOption<DateTime>>
            {
                new SelectableOption<DateTime> { Name = "Test1", Selected= true, Value = DateTime.Now },
                new SelectableOption<DateTime> { Name = "Test2", Selected= true, Value = DateTime.Now },
                new SelectableOption<DateTime> { Name = "Test3", Selected= true, Value = DateTime.Now }
            };

            var result = options.GetSelected();

            Assert.AreEqual(options.Count(), result.Count());
        }

        [Test]
        public void Given_SelectOptionGenericListWithPartiallSelectedTrue_When_GetSelected_Then_JustSelectedRetrived()
        {
            DateTime dateTime1 = DateTime.Now, dateTime2 = DateTime.Now.AddDays(1), dateTime3 = DateTime.Now.AddDays(2);

            var options = new List<SelectableOption<DateTime>>
            {
                new SelectableOption<DateTime> { Name = "Test1", Selected= true, Value = dateTime1 },
                new SelectableOption<DateTime> { Name = "Test2", Selected= true, Value = dateTime2 },
                new SelectableOption<DateTime> { Name = "Test3", Selected= true, Value = dateTime3 },
                new SelectableOption<DateTime> { Name = "Test4", Selected= false, Value = DateTime.Now.AddDays(5) },
                new SelectableOption<DateTime> { Name = "Test5", Selected= false, Value = DateTime.Now.AddDays(5) }
            };

            var result = options.GetSelected();

            Assert.AreEqual(3, result.Count());
            Assert.IsTrue(result.Contains(dateTime1));
            Assert.IsTrue(result.Contains(dateTime2));
            Assert.IsTrue(result.Contains(dateTime3));
        }

        [Test]
        public void Given_SelectOptionGenericListWithNoneSelected_When_GetSelected_Then_EmptyListRetrived()
        {
            var options = new List<SelectableOption<DateTime>>
            {
                new SelectableOption<DateTime> { Name = "Test1", Selected= false, Value = DateTime.Now },
                new SelectableOption<DateTime> { Name = "Test2", Selected= false, Value = DateTime.Now },
                new SelectableOption<DateTime> { Name = "Test3", Selected= false, Value = DateTime.Now },
                new SelectableOption<DateTime> { Name = "Test4", Selected= false, Value = DateTime.Now },
                new SelectableOption<DateTime> { Name = "Test5", Selected= false, Value = DateTime.Now }
            };

            var result = options.GetSelected();

            Assert.IsFalse(result.Any());
        }

    }
}
