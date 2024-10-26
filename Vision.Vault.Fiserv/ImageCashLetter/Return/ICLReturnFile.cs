using System;
using System.Collections.Generic;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record;
using Vision.Vault.Fiserv.ImageCashLetter.Return.Record;

namespace Vision.Vault.Fiserv.ImageCashLetter.Return
{
    public class ICLReturnFile
    {
        public ICLReturnFileHeaderRecord Header { get; set; }
        public ICLReturnFileControlRecord Control { get; set; }

        public List<ICLReturnAccount> Accounts { get; set; } = new List<ICLReturnAccount>();
    }
}
