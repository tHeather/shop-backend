﻿using System;
namespace shop_backend.ViewModels
{
    public class DotPayCallback
    {
        public int id { get; set; }
        public string operation_number { get; set; }
        public string operation_type { get; set; }
        public string operation_status { get; set; }
        public string operation_amount { get; set; }
        public string operation_currency { get; set; }
        public string operation_original_amount { get; set; }
        public string operation_original_currency { get; set; }
        public string operation_datetime { get; set; }
        public int control { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public string p_info { get; set; }
        public string p_email { get; set; }
        public string channel { get; set; }
        public string signature { get; set; }
    }

    public enum DotPayOperationStatus
    {
        Started,
        Completed,
        Rejected
    }
}
