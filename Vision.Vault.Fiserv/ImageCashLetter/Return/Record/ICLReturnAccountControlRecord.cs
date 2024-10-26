using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Return.Record
{
    public class ICLReturnAccountControlRecord : ICLBase
    {
        public ICLReturnAccountControlRecord()
        {
            RecordType = "49";
        }

        public int TotalRecords { get; set; }
        public decimal TotalAmount { get; set; }
        public int BundleCount { get; set; }
        public decimal BundleAmount { get; set; }
        public int ReturnCount { get; set; }
        public decimal ReturnAmount { get; set; }
        public string Filler { get; set; }
        public string OriginalRecord { get; set; }
    }
}
