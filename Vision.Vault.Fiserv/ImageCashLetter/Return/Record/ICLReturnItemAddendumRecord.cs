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

        public int CurrentSequenceNumber { get; set; }
        public int OriginalSequenceNumber { get; set; }
        public string KeyFieldCode1 { get; set; }
        public string KeyedFieldName1 { get; set; }
        public string KeyedFieldData1 { get; set; }
        public string KeyedFieldCode2 { get; set; } 
        public string KeyedFieldName2 { get; set; }
        public string KeyedFieldData2 { get; set; }

        public string Filler { get; set; }


        public string OriginalRecord { get; set; }  
    }
}
