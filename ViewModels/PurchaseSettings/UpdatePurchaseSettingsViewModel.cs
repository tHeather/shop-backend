using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shop_backend.Attributes;
using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class UpdatePurchaseSettingsViewModel
    {
        [Required]
        public bool IsShippingAvaible { get; set; }

        [Required]
        public bool IsPersonalPickupAvaible { get; set; }

        [Required]
        public bool IsDotpayAvaible { get; set; }

        [Required]
        public bool IsCashAvaible { get; set; }

        [Required]
        public bool IsTransferAvaible { get; set; }

        [RequiredIfValidation("IsTransferAvaible", "You need to provide transfer number field")]
        [MaxLength(255)]
        public string TransferNumber { get; set; }
    }
}
