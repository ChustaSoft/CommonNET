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
            if (!IsPropertyTypeValid(value)) 
            { 
                var otherPropertyValue = validationContext.ObjectInstance.GetPropertyValue(_otherProperty);

                if (!IsPropertyTypeValid(otherPropertyValue))
                {
                    var targetPropertyDescription = validationContext.ObjectType.GetDescription(validationContext.MemberName);
                    var otherDescription = validationContext.ObjectType.GetDescription(_otherProperty);

                    return new ValidationResult($"Field {targetPropertyDescription} or {otherDescription} are mandatory");
                }
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
