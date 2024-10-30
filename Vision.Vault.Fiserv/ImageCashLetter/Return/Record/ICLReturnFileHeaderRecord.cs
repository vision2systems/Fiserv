using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record
{
    public class ICLReturnFileHeaderRecord : ICLBase
    {
        public string SendingBankRoutingNumber { get; set; }
        public string SendingBankName { get; set; }
        public string DataSource { get; set; }
        public string ReceivingId { get; set; }
        public string ReceivingName { get; set; }
        public string FileType { get; set; }
        public DateTime FileCreation { get; set; }
        public int FileRecordLength { get; set; }
        public string FileVersion { get; set; }
        public DateTime BusinessDate { get; set; }
        public string FileName { get; set; }
        public string Filler { get; set; }
        
        public string OriginalRecord { get; set; }
    }
}
