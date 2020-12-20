using Microsoft.AspNetCore.Http;
using shop_backend.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.ViewModels.Theme
{
    public class UpdateThemeViewModel
    {

        [ColorValidationAttribute]
        public string LeadingColor { get; set; }

        [ColorValidationAttribute]
        public string SecondaryColor { get; set; }

        [ColorValidationAttribute]
        public string TertiaryColor { get; set; }

        public IFormFile Logo { get; set; }
    }
}
