using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLCheckDetailRecord : ICLBase
    {
        public ICLCheckDetailRecord()
        {
            RecordType = "25";
            DocumentTypeIndicator = "G";
            BOFDIndicator = "Y";
            CheckDetailRecordAddendumCount = 0;
            ArchiveTypeIndicator = "B";
            MICRValidIndicator = "1";

        }
        public string AuxOnUs { get; set; }
        public string ExternalProcessingCode { get; set; }
        public string PayorBankRoutingNumber { get; set; }

        public string OnUs { get; set; }
        public decimal Amount { get; set; } 
        public long ECEInstitutionItemSequenceNumber { get; set; }
        public string DocumentTypeIndicator { get; set; }
        public string ReturnAcceptanceIndicator { get; set; }
        
        public string MICRValidIndicatorIgnore { get; set; }
        public string MICRValidIndicator { get; set; }
        

        public string BOFDIndicator { get; set; }
 

        public int CheckDetailRecordAddendumCount { get; set; }


        public string CorrectionIndicator { get; set; }
       

        public string ArchiveTypeIndicator { get; set; }
       
    }
}
