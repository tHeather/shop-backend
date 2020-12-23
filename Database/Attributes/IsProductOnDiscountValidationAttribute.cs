using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBackend.BusinessLogic.Attributes
{
    public class IsProductOnDiscountValidationAttribute : ValidationAttribute 
    {
        private readonly string booleanPropertyName;

        public IsProductOnDiscountValidationAttribute(string booleanPropertyName)
        {
            this.booleanPropertyName = booleanPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            var property = validationContext.ObjectType.GetProperty(booleanPropertyName);
            if(property == null)
                throw new ArgumentNullException($"Property with name {booleanPropertyName} not found");

            var isOnDiscount = (bool)property.GetValue(validationContext.ObjectInstance);
            if(isOnDiscount && value == null)
                return new ValidationResult("You need to provide discount price.");

            return ValidationResult.Success;            
        }
    }
}
