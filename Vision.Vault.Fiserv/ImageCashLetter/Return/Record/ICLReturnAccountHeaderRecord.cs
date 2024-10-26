using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Return.Record
{
    public class ICLReturnAccountHeaderRecord : ICLBase
    {
        public ICLReturnAccountHeaderRecord()
        {
            RecordType = "03";

        }

        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string MasterAccountNumber { get; set; }
        public string Filler { get; set; }
        public string OriginalRecord { get; set; }

    }
}
