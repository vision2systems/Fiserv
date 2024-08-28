using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLBundleControlRecord : ICLBase
    {
        public ICLBundleControlRecord()
        {
            RecordType = "70";
            CreditTotalIndicator = "1";
        }

        public int ItemCount { get; set; }
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// sent in lieu of micr total amount to ignore micr valid field
        /// </summary>
        public string MICRValidTotalAmountBlank { get; set; }
        public decimal MICRValidTotalAmount { get; set; }
        public int ImagesWithinBundleCount { get; set; }
        public string UserField { get; set; }
  
        public string CreditTotalIndicator { get; set; }
        public string Reserved { get; set; }
    }
}
