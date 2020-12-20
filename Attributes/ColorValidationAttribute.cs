using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace shop_backend.Attributes
{
    public class ColorValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var color = (string)value;

            if (color != null && !Regex.Match(color, "^#[a-fA-F0-9]{6}$").Success)
                return new ValidationResult("Invalid color format.");

            return ValidationResult.Success;
        }
    }
}
