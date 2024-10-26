using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Return.Record
{
    public class ICLReturnItemDetailRecord : ICLBase
    {
        public ICLReturnItemDetailRecord()
        {
            RecordType = "12";
        }

        public string CurrentSequenceNumber { get; set; }
        public string OriginalSequenceNumber { get; set; }
        public string Location { get; set; }
        public string ReturnType { get; set; }
        public string Disposition { get; set; }
        public DateTime DepositDate { get; set; }
        public string MICRRoutingNumber { get; set; }
        public string MICROnUs { get; set; }
        public string MICRAuxOnUs { get; set; }
        public decimal Amount { get; set; }
        public string ReturnReasonCode { get; set; }
        public string ReturnReasonDescription { get; set; }
        public string TimesRepresented { get; set; }
        public string RepresentEffectiveDate { get; set; }
        public string ACHCompanyId { get; set; }
        public decimal ServiceFee { get; set; }
        public string ACHAdminReturnReasonCode { get; set; }
        public string ACHAdminReturnReasonDescription { get; set; }
        public string Filler { get; set; }
        
        public string OriginalRecord { get; set; }

        public List<ICLReturnItemAddendumRecord> Addendums { get; set; } = new List<ICLReturnItemAddendumRecord>();
    }
}
