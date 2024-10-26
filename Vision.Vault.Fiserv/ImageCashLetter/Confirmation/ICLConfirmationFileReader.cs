using FlatFiles;
using FluentFiles.Core;
using FluentFiles.Core.Conversion;
using FluentFiles.FixedLength;
using FluentFiles.FixedLength.Implementation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record;
using Vision.Vault.Fiserv.ImageCashLetter.Converters;
using static System.Net.WebRequestMethods;

namespace Vision.Vault.Fiserv.ImageCashLetter.Confirmation
{
    public class ICLConfirmationFileReader : IDisposable
    {
        private bool UseRecordHeader = false;
        private LongDateConverter _dateConverter = new LongDateConverter();
        private StringWithImpliedDecimalConverter _decimalConverter = new StringWithImpliedDecimalConverter();
        private StringBuilder _currentFile = new StringBuilder();
        private ConfirmationMasterDetailStrategy _masterDetailStrategy = new ConfirmationMasterDetailStrategy();

        public ICLConfirmationFileReader()
        {
        }

        public ICLConfirmationFile Read(Stream stream)
        {
            var buffer = new byte[4];
            //read the first 4 bytes determine if its record length or record type;
            stream.Read(buffer, 0, 4);
            //if the first two bytes are "01" then its a file header record
            var recordtype = Encoding.ASCII.GetString(buffer, 0, 2);
            if (recordtype != "01")
                UseRecordHeader = false;
            else
                UseRecordHeader = true;

            var engine = GetRecordEngine();

            //read the records to populate the full file that is built inside the master detail strategy
            var records = engine.GetRecords<ICLConfirmationBundleDetail>();

            return _masterDetailStrategy.ConfirmationFile;

            

        }

        private IFlatFileMultiEngine GetRecordEngine()
        {
            var factory = new FixedLengthFileEngineFactory();


            var layouts = (IEnumerable<IFixedLengthLayoutDescriptor>)new List<IFixedLengthLayoutDescriptor>()
            {
                FileHeaderLayout(),
                CashLetterDepositHeaderLayout(),
                BundleDetailLayout(),
                CashLetterDepositControlLayout(),
                FileControlLayout(),

            };

            var flatFile = factory.GetEngine(layouts, (line, idx) =>
            {
                // For each line, return the proper record type.
                // The mapping for this line will be loaded based on that type.
                // In this simple example, the first character determines the
                // record type.
                if (String.IsNullOrEmpty(line) || line.Length < 1) return null;

                
                    var recType = line.Substring(0, 2);

                    switch (recType)
                    {
                        case "01":
                            
                            return typeof(ICLConfirmationFileHeader);
                        case "10":
                            if (_currentFile != null)
                            {
                                _currentFile.AppendLine(line);
                            }
                            _currentFile = null;
                            return typeof(ICLConfirmationCashLetterDepositHeader);
                        case "20":
                            _currentFile.AppendLine(line);
                            return typeof(ICLConfirmationBundleDetail);
                        case "90":
                            _currentFile.AppendLine(line);
                            return typeof(ICLConfirmationCashLetterDepositControl);
                        case "99":
                            _currentFile.AppendLine(line);
                            return typeof(ICLConfirmationFileControl);
                        
                        default:

                            break;

                    }


                
                return null;

            }, null, _masterDetailStrategy);


            return flatFile;
        }

        

        public IFixedLengthLayoutDescriptor FileHeaderLayout()
        {
            var layout = new FixedLayout<ICLReturnFileHeaderRecord>();
            if(UseRecordHeader)
            {
                layout.WithMember(c => c.RecordHeader, x => x.WithLength(4));
            }

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
            .WithMember(c => c.SendingBankRoutingNumber, x => x.WithLength(9))
            .WithMember(c => c.SendingBankName, x => x.WithLength(16))
            .WithMember(c => c.DataSource, x => x.WithLength(3))
            .WithMember(c => c.ReceivingId, x => x.WithLength(9))
            .WithMember(c => c.ReceivingName, x => x.WithLength(20))
            .WithMember(c => c.FileType, x => x.WithLength(1))
            .WithMember(c => c.FileCreation, x => x.WithLength(14).WithConverter(_dateConverter))
            .WithMember(c => c.Reserved, x => x.WithLength(6));

            return layout;
        }

        public IFixedLengthLayoutDescriptor CashLetterDepositHeaderLayout()
        {
            var layout = new FixedLayout<ICLConfirmationCashLetterDepositHeader>();
            if (UseRecordHeader)
            {
                layout.WithMember(c => c.RecordHeader, x => x.WithLength(4));
            }

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
            .WithMember(c => c., x => x.WithLength(9))
            .WithMember(c => c.FileReceiveDate, x => x.WithLength(14).WithConverter(_dateConverter))
            .WithMember(c => c.CashLetterId, x => x.WithLength(8))
            .WithMember(c => c.Reserved, x => x.WithLength(3));
            
            
            return layout;
        }

        public IFixedLengthLayoutDescriptor BundleDetailLayout()
        {
            var layout = new FixedLayout<ICLConfirmationBundleDetail>();
            if (UseRecordHeader)
            {
                layout.WithMember(c => c.RecordHeader, x => x.WithLength(4));
            }

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
                .WithMember(c => c.BundleId, x => x.WithLength(10))
                .WithMember(c => c.TotalItems, x => x.WithLength(8))
                .WithMember(c => c.TotalAmount, x => x.WithLength(15).WithConverter(_decimalConverter))
                .WithMember(c => c.TotalCheckImages, x => x.WithLength(8))
                .WithMember(c => c.DepositStatus, x => x.WithLength(2))
                .WithMember(c => c.Reserved, x => x.WithConverter(34));

            return layout;
        }

        public IFixedLengthLayoutDescriptor CashLetterDepositControlLayout()
        {
            var layout = new FixedLayout<ICLConfirmationCashLetterDepositControl>();
            if (UseRecordHeader)
            {
                layout.WithMember(c => c.RecordHeader, x => x.WithLength(4));
            }

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
                .WithMember(c => c.TotalRecords, x => x.WithLength(10))
                .WithMember(c => c.TotalItems, x => x.WithLength(15))
                .WithMember(c => c.TotalAmount, x => x.WithLength(18).WithConverter(_decimalConverter))
                .WithMember(c => c.TotalCheckImages, x => x.WithLength(15))
                .WithMember(c => c.TotalWithStatus01, x => x.WithLength(5))
                .WithMember(c => c.Reserved, x => x.WithLength(15));

            return layout;
        }

        public IFixedLengthLayoutDescriptor FileControlLayout()
        {
            var layout = new FixedLayout<ICLConfirmationFileControl>();
            if (UseRecordHeader)
            {
                layout.WithMember(c => c.RecordHeader, x => x.WithLength(4));
            }

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
               .WithMember(c => c.TotalRecords, x => x.WithLength(15))
               .WithMember(c => c.Reserved, x => x.WithLength(63));

            return layout;
        }

        public void Dispose()
        {
            _masterDetailStrategy = null;

        }
    }
}
