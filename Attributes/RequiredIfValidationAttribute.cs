using System;
using System.ComponentModel.DataAnnotations;

namespace shop_backend.Attributes
{
    public class RequiredIfValidationAttribute : ValidationAttribute
    {
        private readonly string dependentPropertyName;
        private readonly string errorMessage;

        public RequiredIfValidationAttribute(string dependentPropertyName, string errorMessage)
        {
            this.dependentPropertyName = dependentPropertyName;
            this.errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(dependentPropertyName);
            if (property == null)
                throw new ArgumentNullException($"Property with name {dependentPropertyName} not found");

            var dependentProperty = (bool)property.GetValue(validationContext.ObjectInstance);
            if (dependentProperty && value == null)
            {
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
