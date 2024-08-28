using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLBundleHeaderRecord : ICLBase
    {
        public ICLBundleHeaderRecord()
        {
            RecordType = "20";
        }
        public string CollectionTypeIndicator { get; set; }
        public string DestinationRoutingNumber { get; set; }

        public string ECEInstituionRoutingNumber { get; set; }
        
        public DateTime BusinessDate { get; set; }
        public DateTime CreationDate { get; set; }
        public long BundleId { get; set; }

        public long SequenceNumber { get; set; }

        public int CycleNumber { get; set; }

        public string Reserved { get; set; }
    }
}
