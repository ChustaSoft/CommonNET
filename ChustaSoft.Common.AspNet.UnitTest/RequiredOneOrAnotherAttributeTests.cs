using ChustaSoft.Common.Validators;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChustaSoft.Common.AspNet.UnitTest
{
    public class RequiredOneOrAnotherAttributeTests
    {

        [Test]
        public void Given_PropertiesRelatedInitialInformed_When_IsValidBypass_Then_TrueRetrieved()
        {
            var classObj = new TestClass { TestString = "Test value" };            
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClass.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.True(result);
        }

        [Test]
        public void Given_PropertiesRelatedOtherInformed_When_IsValidBypass_Then_TrueRetrieved()
        {
            var classObj = new TestClass { TestInt = 5 };
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClass.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.True(result);
        }

        [Test]
        public void Given_PropertiesRelatedNoneInformed_When_IsValidBypass_Then_FalseRetrieved()
        {
            var classObj = new TestClass { };
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClass.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.False(result);
        }


        [Test]
        public void Given_PropertiesRelatedBothInformed_When_IsValidBypass_Then_TrueRetrieved()
        {
            var classObj = new TestClass { TestString = "Test", TestInt = 5 };
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClass.TestString) };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(classObj, validationContext, validationResults, true);

            Assert.True(result);
        }


        private class TestClass
        {
            [RequiredOneOrAnother("TestInt")]
            public string TestString { get; set; }
            public int TestInt { get; set; }
        }
    }
}
