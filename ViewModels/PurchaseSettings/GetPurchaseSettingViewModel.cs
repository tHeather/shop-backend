using System.Collections.Generic;
using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class GetPurchaseSettingViewModel
    {
        public GetPurchaseSettingViewModel(PurchaseSettings purchaseSettings, List<PersonalPickupBranch> personalPickupBranches)
        {
            IsShippingAvaible = purchaseSettings.IsShippingAvaible;
            IsPersonalPickupAvaible = purchaseSettings.IsPersonalPickupAvaible;
            PersonalPickupBranches = new List<GetPersonalPickupBranchViewModel>();
            IsDotpayAvaible = purchaseSettings.IsDotpayAvaible;
            IsCashAvaible = purchaseSettings.IsCashAvaible;
            IsTransferAvaible = purchaseSettings.IsTransferAvaible;
            TransferNumber = purchaseSettings.TransferNumber;

            foreach(var branch in personalPickupBranches)
            {
                PersonalPickupBranches.Add(new GetPersonalPickupBranchViewModel(branch));
            }
        }

        public bool IsShippingAvaible { get; set; }

        public bool IsPersonalPickupAvaible { get; set; }

        public List<GetPersonalPickupBranchViewModel> PersonalPickupBranches { get; set; }

        public bool IsDotpayAvaible { get; set; }

        public bool IsCashAvaible { get; set; }

        public bool IsTransferAvaible { get; set; }

        public string TransferNumber { get; set; }
    }
}
