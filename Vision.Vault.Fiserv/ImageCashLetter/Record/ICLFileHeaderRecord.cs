using System;
using FlatFiles;
using FlatFiles.TypeMapping;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLFileHeaderRecord : ICLBase
    {

       

        public ICLFileHeaderRecord()
        {
            RecordType = "01";
            StandardLevel = "03";
            TestFileIndicator = "P";
            ResendIndicator = "N";
        }
        public string StandardLevel { get; set; }
        public string TestFileIndicator { get; set; }
        public string ImmediateDestinationRoutingNumber { get; set; }
        public string ImmediateOriginRoutingNumber { get; set; }

        public DateTime FileDate { get; set; }

        public string ImmediateDestinationName { get; set; }
        public string ImmediateOriginName { get; set; }
        public string ResendIndicator { get; set; }

        public string VersionIndicator { get; set; }

        public string FileModifier { get; set; }

        public string CountryCode { get; set; }

        public string UserField { get; set; }

        public string CompanionDocumentVersion { get; set; }

        public string Reserved { get; set; }
    }
}
