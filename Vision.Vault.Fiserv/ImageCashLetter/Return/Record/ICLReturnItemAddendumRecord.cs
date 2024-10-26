using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Return.Record
{
    public class ICLReturnItemAddendumRecord : ICLBase
    {
        public ICLReturnItemAddendumRecord()
        {
            RecordType = "16";
        }


        public string OriginalRecord { get; set; }  
    }
}
