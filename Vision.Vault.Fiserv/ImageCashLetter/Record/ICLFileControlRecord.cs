using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLFileControlRecord : ICLBase
    {
        public ICLFileControlRecord()
        {
            RecordType = "99";
            Reserved = "";
        }

        public int CashLetterCount { get; set; }
        public int TotalRecordCount { get; set; }
        public int TotalItemCount { get; set; }

        public decimal TotalAmount { get; set; } 
        //public decimal TotalFileCreditAmount { get; set; }


        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string Reserved { get; set; }
    }
}
