using ChustaSoft.Common.Validators;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChustaSoft.Common.AspNet.UnitTest
{
    public class RequiredOneOrAnotherAttributeTests
    {

        [Test]
        public void Given_PropertiesRelatedInitialInformed_When_TryValidateObject_Then_TrueRetrieved()
        {
            var classObj = new TestClassA { TestString = "Test value" };            
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClassA.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.True(result);
        }

        [Test]
        public void Given_PropertiesRelatedOtherInformed_When_TryValidateObject_Then_TrueRetrieved()
        {
            var classObj = new TestClassA { TestInt = 5 };
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClassA.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.True(result);
        }

        [Test]
        public void Given_PropertiesRelatedNoneInformed_When_TryValidateObject_Then_FalseRetrieved()
        {
            var classObj = new TestClassA { };
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClassA.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.False(result);
        }


        [Test]
        public void Given_PropertiesRelatedBothInformed_When_TryValidateObject_Then_TrueRetrieved()
        {
            var classObj = new TestClassA { TestString = "Test", TestInt = 5 };
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClassA.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.True(result);
        }

        [Test]
        public void Given_PropertiesRelatedMainIntegerOtherStringInformed_When_TryValidateObject_Then_TrueRetrieved()
        {
            var classObj = new TestClassB { TestString = "Test" };
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClassA.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.True(result);
        }

        [Test]
        public void Given_PropertiesRelatedMainIntegerOtherStringNull_When_TryValidateObject_Then_FalseRetrieved()
        {
            var classObj = new TestClassB { };
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClassA.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.False(result);
        }


        private class TestClassA
        {
            [RequiredOneOrAnother("TestInt")]
            public string TestString { get; set; }
            public int TestInt { get; set; }
        }

        private class TestClassB
        {
            public string TestString { get; set; }
            [RequiredOneOrAnother("TestString")]
            public int TestInt { get; set; }
        }
    }
}
