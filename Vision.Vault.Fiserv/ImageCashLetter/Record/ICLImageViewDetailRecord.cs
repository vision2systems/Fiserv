using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLImageViewDetailRecord: ICLBase
    {
        public ICLImageViewDetailRecord()
        {
            RecordType = "50";
            DigitalSignatureIndicator = "0";
            ImageViewFormat = "00";
            ImageViewCompressionAlgorithm = "00";
            ImageReCreateIndicator = "0";
            ImageIndicator = "1";
            ViewDescriptor = "00";
        }

        
        public string ImageIndicator { get; set; }
        

        public string ImageCreatorRoutingNumber { get; set; }
        

        public DateTime ImageCreationDate { get; set; }
        

        public string ImageViewFormat { get; set; }
        

        public string ImageViewCompressionAlgorithm { get; set; }
        

        public int ImageViewDataSize { get; set; }
        

        public string ViewSide { get; set; }
        

        public string ViewDescriptor { get; set; }
        

        public string DigitalSignatureIndicator { get; set; }
        

        public string DigitalSignatureMethod { get; set; }
        

        public string SecurityKeySize { get; set; }
        

        public string StartOfProtectedData { get; set; }
        

        public string LengthOfProtectedData { get; set; }
        

        public string ImageReCreateIndicator { get; set; }
        

        public string OverrideIndicator { get; set; }

        public string UserField { get; set; }
        

        public string Reserved { get; set; }
        


    }
}
