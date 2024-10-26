using System;
using System.Collections.Generic;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Return.Record;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLReturnItem
    {
        public ICLCheckDetailRecord Detail { get; set; }
        public List<ICLReturnItemAddendumRecord> AdditionalRecords { get; set; } = new List<ICLReturnItemAddendumRecord>();
        public ICLReturnItem()
        {
        }
    }
}
