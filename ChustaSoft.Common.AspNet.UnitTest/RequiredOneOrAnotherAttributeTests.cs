using ChustaSoft.Common.Validators;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace ChustaSoft.Common.AspNet.UnitTest
{
    public class RequiredOneOrAnotherAttributeTests
    {

        [Test]
        public void Given_PropertiesRelatedInitialInformed_When_IsValidBypass_Then_NullRetrieved()
        {
            var classObj = new TestClass { TestString = "Test value" };
            var validator = new RequiredOneOrAnotherAttributeTestObj(nameof(TestClass.TestInt));
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClass.TestString) };

            var result = validator._IsValid(classObj, validationContext);

            Assert.IsNull(result);
        }

        [Test]
        public void Given_PropertiesRelatedOtherInformed_When_IsValidBypass_Then_NullRetrieved()
        {
            var classObj = new TestClass { TestInt = 5 };
            var validator = new RequiredOneOrAnotherAttributeTestObj(nameof(TestClass.TestString));
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClass.TestInt) };

            var result = validator._IsValid(classObj, validationContext);

            Assert.IsNull(result);
        }

        [Test]
        public void Given_PropertiesRelatedNoneInformed_When_IsValidBypass_Then_ErrorMessageRetrieved()
        {
            var classObj = new TestClass { };
            var validator = new RequiredOneOrAnotherAttributeTestObj(nameof(TestClass.TestString));
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClass.TestInt) };

            var result = validator._IsValid(classObj, validationContext);

            Assert.IsNotNull(result.ErrorMessage);
        }


        [Test]
        public void Given_PropertiesRelatedBothInformed_When_IsValidBypass_Then_NullRetrieved()
        {
            var classObj = new TestClass { TestString = "Test", TestInt = 5 };
            var validator = new RequiredOneOrAnotherAttributeTestObj(nameof(TestClass.TestString));
            var validationContext = new ValidationContext(classObj) { MemberName = nameof(TestClass.TestInt) };

            var result = validator._IsValid(classObj, validationContext);

            Assert.IsNull(result);
        }



        private class RequiredOneOrAnotherAttributeTestObj : RequiredOneOrAnotherAttribute
        {
            public RequiredOneOrAnotherAttributeTestObj(string otherProperty) 
                : base(otherProperty)
            { }

            internal ValidationResult _IsValid(object value, ValidationContext validationContext)
                => base.IsValid(value, validationContext);
        }

        private class TestClass
        {
            public string TestString { get; set; }
            public int TestInt { get; set; }
        }
    }
}
