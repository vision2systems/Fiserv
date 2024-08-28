using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLImageRecord : ICLBase
    {
      
        public ICLImageRecord()
        {
            RecordType = "52";
            CycleNumber = "01";
            ClippingOrigin = "0";
            ImageData = Array.Empty<byte>();
            LengthOfImageReferenceKey = 0;
            LengthOfDigitalSignature = "0000";
        
        }

        public override int RecordLength => 117 + LengthOfImageData;

        
      
        

        public string ECEInstitutionRoutingNumber { get; set; }
        

        public DateTime BundleBusinessDate { get; set; }
        

        public string CycleNumber { get; set; }
        
        public long ECEItemSequenceNumber { get; set; }
       

        public string SecurityOriginatorName { get; set; }
        

        public string SecurityAuthenticatorName { get; set; }
        

        public string SecurityKeyName { get; set; }
        

        public string ClippingOrigin { get; set; }
        

        public string ClippingCoordinateH1 { get; set; }
        

        public string ClippingCoordinateH2 { get; set; }
        

        public string ClippingCoordinateV1 { get; set; }
        

        public string ClippingCoordinateV2 { get; set; }
        

        public int LengthOfImageReferenceKey { get; set; }
        

        public long ImageReferenceKey { get; set; }
        

        public string LengthOfDigitalSignature { get; set; }
        

        public string DigitalSignature { get; set; }
        

        public int LengthOfImageData => ImageData.Length;


        public byte[] ImageData { get; set; }

        
      
    }
}
