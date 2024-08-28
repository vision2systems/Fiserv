using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLCashLetterControlRecord : ICLBase
    {
        public ICLCashLetterControlRecord()
        {
            RecordType = "90";
        }
        public int BundleCount { get; set; }

        
        public int ItemCount { get; set; }
        public decimal TotalAmount { get; set; }
        public int ImageCount { get; set; }

        public string ECEInstitutionName { get; set; }

        public DateTime SettlementDate { get; set; }

        public string Reserved { get; set; }
    }
}
