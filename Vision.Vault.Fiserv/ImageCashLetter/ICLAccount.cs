using System;
using System.Collections.Generic;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Return.Record;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLAccount
    {
        public ICLReturnAccountHeaderRecord Header { get; set; } = new ICLReturnAccountHeaderRecord();
        public ICLReturnAccountControlRecord Control { get; set; } = new ICLReturnAccountControlRecord();
        public List<ICLReturnItemDetailRecord> Returns { get; set; } = new List<ICLReturnItemDetailRecord>();
    }
}
