using System;
using System.Collections.Generic;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Return.Record;

namespace Vision.Vault.Fiserv.ImageCashLetter.Return
{
    public class ICLReturnFile
    {
        public ICLReturnAccountHeaderRecord Header { get; set; }
        public ICLReturnAccountControlRecord Control { get; set; }

        public List<ICLReturnAccount> Accounts { get; set; } = new List<ICLReturnAccount>();
    }
}
