using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record
{
    public class ICLConfirmationCashLetterDepositControl : ICLBase
    {
        public int TotalRecords { get; set; }
        public int TotalItems { get; set; }

        public decimal TotalAmount { get; set; }

        public int TotalCheckImages { get; set; }

        public string TotalWithStatus01 { get; set; }

        public string Reserved { get; set; }

        public string OriginalRecord { get; set; }
    }
}
