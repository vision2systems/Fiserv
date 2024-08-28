using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLCashLetterHeaderRecord : ICLBase
    {
        public ICLCashLetterHeaderRecord()
        {
            RecordType = "10";
            CollectionTypeIndicator = "01";
            CashLetterRecordTypeIndicator = "I";
            CashLetterDocumentTypeIndicator = "G";
            FedWorkType = "C";
            
        }

        public string CollectionTypeIndicator { get; set; }

        public string DestinationRoutingNumber { get; set; }

        public string ECEInstitituionRoutingNumber { get; set; }

        public DateTime BusinessDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string CashLetterRecordTypeIndicator { get; set; }

        public string CashLetterDocumentTypeIndicator { get; set; }

        

        public long CashLetterId { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string FedWorkType { get; set; }

        public string ReturnsIndicator { get; set; }
        public string UserField { get; set; }
        public string Reserved { get; set; }
    }
}
