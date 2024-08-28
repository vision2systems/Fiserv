using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLBundleBuilder : IDisposable
    {

        private ICLCashLetterBuilder _cashLetterBuilder;
        private IICLDepositSlipGenerator _depositSlipGenerator;
        private string _depositAccountNumber;
        private string _depositRoutingNumber;
        private string _endorsedBy;

        private ICLCheckDetailRecord _creditRecord;
        private ICLImageViewDetailRecord _depositSlipFrontDetail;
        private ICLImageViewDetailRecord _depositSlipBackDetail;
        private ICLImageRecord _depositSlipFront;
        private ICLImageRecord _depositSlipBack;

        private ICLBundle Bundle { get; set; } = new ICLBundle();


        internal ICLBundleBuilder(ICLCashLetterBuilder cashLetterBuilder,
            IICLDepositSlipGenerator depositSlipGenerator,
            DateTime businessDate,
            long bundleId,
            string depositAccountNumber,
            string depositRoutingNumber, //ImmediateOriginRoutingNumber and ECEInstituionRoutingNumber
            string endorsedBy,
            long depositTicketSequenceNumber)
        {
            _cashLetterBuilder = cashLetterBuilder;
            _depositAccountNumber = depositAccountNumber;
            _depositRoutingNumber = depositRoutingNumber;
            _depositSlipGenerator = depositSlipGenerator;
            _endorsedBy = endorsedBy;

            Bundle.BundleHeader.BundleId = bundleId;
            Bundle.BundleHeader.BusinessDate = businessDate;
            Bundle.BundleHeader.CreationDate = DateTime.UtcNow;
            Bundle.BundleHeader.SequenceNumber = cashLetterBuilder.Bundles.Count + 1;
            Bundle.BundleHeader.DestinationRoutingNumber = cashLetterBuilder.CashLetterHeader.DestinationRoutingNumber;
            Bundle.BundleHeader.ECEInstituionRoutingNumber = cashLetterBuilder.CashLetterHeader.ECEInstitituionRoutingNumber;
            Bundle.BundleHeader.CollectionTypeIndicator = cashLetterBuilder.CashLetterHeader.CollectionTypeIndicator;
            Bundle.BundleHeader.CycleNumber = 1;

            AddDepositSlip(depositTicketSequenceNumber);

            _cashLetterBuilder.Bundles.Add(Bundle);




        }

        public void AddDepositSlip(long sequenceNumber)
        {
            Bundle.Records.Add(Bundle.BundleHeader);

            _creditRecord = new ICLCheckDetailRecord();

            if (!_depositAccountNumber.Contains("/"))
            {
                //210 is the credit transaction code for deposit
                _creditRecord.OnUs = _depositAccountNumber + "/210";
            }


            _creditRecord.PayorBankRoutingNumber = _depositRoutingNumber;
            _creditRecord.ECEInstitutionItemSequenceNumber = sequenceNumber;

            Bundle.Records.Add(_creditRecord);


            _depositSlipFrontDetail = new ICLImageViewDetailRecord();
            _depositSlipFrontDetail.ViewSide = "0";
            _depositSlipFrontDetail.ImageCreatorRoutingNumber = _cashLetterBuilder.CashLetterHeader.ECEInstitituionRoutingNumber;
            _depositSlipFrontDetail.ImageCreationDate = DateTime.UtcNow;


            Bundle.Records.Add(_depositSlipFrontDetail);



            _depositSlipFront = new ICLImageRecord();
            _depositSlipFront.ECEItemSequenceNumber = sequenceNumber;
            _depositSlipFront.BundleBusinessDate = Bundle.BundleHeader.BusinessDate;
            _depositSlipFront.ECEInstitutionRoutingNumber = _cashLetterBuilder.CashLetterHeader.ECEInstitituionRoutingNumber;
            Bundle.Records.Add(_depositSlipFront);


            _depositSlipBackDetail = new ICLImageViewDetailRecord();
            _depositSlipBackDetail.ViewSide = "1";
            _depositSlipBackDetail.ImageCreatorRoutingNumber = _cashLetterBuilder.CashLetterHeader.ECEInstitituionRoutingNumber;
            _depositSlipBackDetail.ImageCreationDate = DateTime.UtcNow;

            Bundle.Records.Add(_depositSlipBackDetail);

            _depositSlipBack = new ICLImageRecord();
            _depositSlipBack.BundleBusinessDate = Bundle.BundleHeader.BusinessDate;
            _depositSlipBack.ImageData = _depositSlipGenerator.CreateDepositSlipBack(_endorsedBy);
            _depositSlipBack.ECEItemSequenceNumber = sequenceNumber;
            _depositSlipBack.BundleBusinessDate = Bundle.BundleHeader.BusinessDate;
            _depositSlipBack.ECEInstitutionRoutingNumber = _cashLetterBuilder.CashLetterHeader.ECEInstitituionRoutingNumber;

            _depositSlipBackDetail.ImageViewDataSize = _depositSlipBack.ImageData.Length;

            Bundle.RecordType25Count++;
            Bundle.ImageCount += 2;

            Bundle.Records.Add(_depositSlipBack);

        }


        /// <summary>
        /// Adds a check to the ICL Bundle to be deposited
        /// </summary>
        /// <param name="amount">Amount of the check</param>
        /// <param name="routingNumber">From MICR on Check</param>
        /// <param name="accountNumber">Account Number from MICR on Check</param>
        /// <param name="auxOnUs">From MICR on Check often this is the serial number or check number</param>
        /// <param name="externalProcessingCode">From MICR on check</param>
        /// <param name="frontImage">Front tiff image serialized as byte array</param>
        /// <param name="backImage">Back tiff image serialized as byte array</param>
        /// <param name="sequenceNumber">Sequence number unique to customer at the bank</param>
        /// <param name="imageCreationDate">The date the image was created</param>
        public void AddDepositWithCheckImages(decimal amount, string routingNumber, string onUs, string auxOnUs, string externalProcessingCode,
            byte[] frontImage, byte[] backImage, long sequenceNumber, DateTime imageCreationDate)
        {

            var deposit = new ICLCheckDetailRecord();
            deposit.AuxOnUs = auxOnUs;
            //remove spaces end with /
            if (!String.IsNullOrEmpty(onUs))
            {
                deposit.OnUs = onUs.Replace(" ", "");

            }
            
            if(onUs!= null && !onUs.EndsWith("/"))
            {
                
                deposit.OnUs = onUs + "/";
            }
            
            if(onUs == null)
            {
                deposit.OnUs = "";
            }


            deposit.PayorBankRoutingNumber = routingNumber;
            deposit.ECEInstitutionItemSequenceNumber = sequenceNumber;
            deposit.Amount = amount;
            
            if(String.IsNullOrEmpty(onUs))
             {
                deposit.MICRValidIndicator = "2";
            }


            var frontImageDetail = new ICLImageViewDetailRecord();
            frontImageDetail.ViewSide = "0";
            frontImageDetail.ImageViewDataSize = frontImage.Length;
            frontImageDetail.ImageCreatorRoutingNumber = _cashLetterBuilder.CashLetterHeader.ECEInstitituionRoutingNumber;
            frontImageDetail.ImageCreationDate = imageCreationDate;
            frontImageDetail.ImageCreatorRoutingNumber = routingNumber;





            var frontImageRecord = new ICLImageRecord();
            frontImageRecord.ImageData = frontImage;
            frontImageRecord.BundleBusinessDate = Bundle.BundleHeader.BusinessDate;
            frontImageRecord.ECEItemSequenceNumber = sequenceNumber;
            frontImageRecord.ECEInstitutionRoutingNumber = _cashLetterBuilder.CashLetterHeader.ECEInstitituionRoutingNumber;



            var backImageDetail = new ICLImageViewDetailRecord();
            backImageDetail.ViewSide = "1";
            backImageDetail.ImageViewDataSize = backImage.Length;
            backImageDetail.ImageCreatorRoutingNumber = _cashLetterBuilder.CashLetterHeader.ECEInstitituionRoutingNumber;
            backImageDetail.ImageCreationDate = imageCreationDate;
            backImageDetail.ImageCreatorRoutingNumber = routingNumber;



            var backImageRecord = new ICLImageRecord();
            backImageRecord.ImageData = backImage;
            backImageRecord.BundleBusinessDate = Bundle.BundleHeader.BusinessDate;
            backImageRecord.ECEItemSequenceNumber = sequenceNumber;
            backImageRecord.ECEInstitutionRoutingNumber = _cashLetterBuilder.CashLetterHeader.ECEInstitituionRoutingNumber;


            Bundle.Records.Add(deposit);
            Bundle.Records.Add(frontImageDetail);
            Bundle.Records.Add(frontImageRecord);
            Bundle.Records.Add(backImageDetail);
            Bundle.Records.Add(backImageRecord);

            Bundle.TotalAmount += amount;
            Bundle.RecordType25Count++;
            Bundle.ImageCount += 2;

            if (deposit.MICRValidIndicator != "2")
            {
                Bundle.MICRValidTotalAmount += amount;
            }

            //add the amount to the credit record and to the total amount for the bundle
            _creditRecord.Amount += amount;
            Bundle.TotalAmount += amount;
        }

        public void Dispose()
        {
            Bundle.BundleControl.ItemCount = Bundle.RecordType25Count;
            Bundle.BundleControl.TotalAmount = Bundle.TotalAmount;
            Bundle.BundleControl.ImagesWithinBundleCount = Bundle.ImageCount;
            Bundle.BundleControl.MICRValidTotalAmount = Bundle.MICRValidTotalAmount;

            _depositSlipFront.ImageData = _depositSlipGenerator.CreateDepositSlipFront(_depositAccountNumber, Bundle.BundleHeader.BusinessDate, Bundle.TotalAmount, _cashLetterBuilder.DestinationName);
            _depositSlipFrontDetail.ImageViewDataSize = _depositSlipFront.ImageData.Length;
            Bundle.Records.Add(Bundle.BundleControl);
        }
    }
}
