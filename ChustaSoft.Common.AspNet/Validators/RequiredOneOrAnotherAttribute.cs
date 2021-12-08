using ChustaSoft.Common.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ChustaSoft.Common.Validators
{
    public class RequiredOneOrAnotherAttribute : ValidationAttribute, IClientModelValidator
    {

        private readonly string _otherProperty;


        public RequiredOneOrAnotherAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property1Value = value.GetPropertyValue(validationContext.MemberName);
            var property2Value = value.GetPropertyValue(_otherProperty);

            if (!IsPropertyTypeValid(property1Value) && !IsPropertyTypeValid(property2Value))
            {
                var property1Description = validationContext.ObjectType.GetDescription(validationContext.MemberName);
                var property2Description = validationContext.ObjectType.GetDescription(_otherProperty);

                return new ValidationResult($"Field {property1Description} or {property2Description} are mandatory");
            }

            return null;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            const string validationKey = "data-val-oneoranother";
            if (context.Attributes.ContainsKey(validationKey))
                context.Attributes.Add(validationKey, $"Property required");
        }

        private bool IsPropertyTypeValid(object property) 
        {
            if (property == null)
                return false;

            switch (property.GetType().Name)
            {
                case "Int32":
                    return !((int)property == 0);

                case "string":
                default:
                    return !string.IsNullOrEmpty(property as string);
            }
        }

    }
}
