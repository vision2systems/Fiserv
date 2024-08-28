using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLCashLetterBuilder : IDisposable
    {
        private readonly ICLFileBuilder _fileBuilder;
        internal ICLCashLetter CashLetter = new ICLCashLetter();

        internal ICLCashLetterHeaderRecord CashLetterHeader => CashLetter.Header;
        internal ICLCashLetterControlRecord CashLetterControl => CashLetter.Control;
        internal List<ICLBundle> Bundles => CashLetter.Bundles;

        internal ICLCashLetterBuilder(ICLFileBuilder fileBuilder, long cashLetterId,
             string routingNumber, DateTime businessDate)
        {
            _fileBuilder = fileBuilder;
            _fileBuilder.CashLetters.Add(CashLetter);

            CashLetterHeader.ECEInstitituionRoutingNumber = routingNumber;
            CashLetterHeader.DestinationRoutingNumber = routingNumber;
            CashLetterHeader.BusinessDate = businessDate;
            CashLetterHeader.CreationDate = DateTime.UtcNow;
            CashLetterHeader.CashLetterId = cashLetterId;
            CashLetterHeader.CollectionTypeIndicator = "01";
            CashLetterHeader.ContactName = fileBuilder.ContactName;
            CashLetterHeader.ContactPhone = fileBuilder.ContactPhoneNumber;

            _fileBuilder.Records.Add(CashLetterHeader);
        }

        public ICLBundleBuilder CreateBundle(long bundleId, long depositTicketSequenceNumber)
        {
            return new ICLBundleBuilder(this, _fileBuilder.DepositSlipGenerator, CashLetterHeader.BusinessDate, bundleId, _fileBuilder.DepositAccountNumber, _fileBuilder.ImmediateOriginRoutingNumber, _fileBuilder.CustomerName, depositTicketSequenceNumber);

        }

        internal string DestinationName
        {
            get => _fileBuilder.ImmediateDestinationName;
        }
        public void Dispose()
        {
            CashLetterControl.TotalAmount = Bundles.Sum(s => s.TotalAmount);  //sum of type 25 records
            CashLetterControl.ItemCount = Bundles.Sum(s => s.RecordType25Count);
            CashLetterControl.ImageCount = Bundles.Sum(s => s.ImageCount);
            CashLetterControl.ECEInstitutionName = _fileBuilder.ImmediateDestinationName;
            CashLetterControl.SettlementDate = _fileBuilder.SettlementDate;
            CashLetterControl.BundleCount = Bundles.Count;

            foreach (var b in Bundles)
            {
                _fileBuilder.Records.AddRange(b.Records);
            }


            _fileBuilder.Records.Add(CashLetterControl);

        }
    }
}
