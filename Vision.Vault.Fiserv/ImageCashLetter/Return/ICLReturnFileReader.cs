using FluentFiles.Core;
using FluentFiles.FixedLength.Implementation;
using FluentFiles.FixedLength;
using System;
using System.Collections.Generic;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record;
using Vision.Vault.Fiserv.ImageCashLetter.Converters;
using Microsoft.Win32.SafeHandles;
using Vision.Vault.Fiserv.ImageCashLetter.Return.Record;

namespace Vision.Vault.Fiserv.ImageCashLetter.Return
{
    public class ICLReturnFileReader : IDisposable
    {
        private bool UseRecordHeader = false;
        private int standardRecordLength = 80;
        private int standardImageRecordLength = 117;
        private ShortDateConverter _shortdateConverter = new ShortDateConverter();
        private LongDateConverter _dateConverter = new LongDateConverter();
        private StringWithImpliedDecimalConverter _decimalConverter = new StringWithImpliedDecimalConverter();

        public int StandardRecordLength => UseRecordHeader ? standardRecordLength : standardRecordLength + 80;

        public ICLReturnFileReader()
        {

        }

        public IFlatFileMultiEngine GetRecordEngine()
        {
            var layouts = new List<IFixedLengthLayoutDescriptor>()
            {
                FileHeaderLayout(),
                AccountHeaderLayout(),
                ReturnItemDetailLayout(),
                AddendumLayout(),
                AccountControlLayout(),
                FileControlLayout()
            };
        }

        public IFixedLengthLayoutDescriptor FileHeaderLayout()
        {
            var layout = new FixedLayout<ICLReturnFileHeaderRecord>();


            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
            .WithMember(c => c.SendingBankRoutingNumber, x => x.WithLength(9))
            .WithMember(c => c.SendingBankName, x => x.WithLength(16))
            .WithMember(c => c.DataSource, x => x.WithLength(3))
            .WithMember(c => c.FileType, x => x.WithLength(1))
            .WithMember(c => c.FileCreation, x => x.WithLength(14).WithConverter(_dateConverter))
            .WithMember(c => c.ReceivingId, x => x.WithLength(9))
            .WithMember(c => c.ReceivingName, x => x.WithLength(20))
            .WithMember(c => c.BusinessDate, x => x.WithLength(6).WithConverter(_shortdateConverter))
            .WithMember(c => c.FileName, x => x.WithLength(30))
            .WithMember(c => c.Filler, x => x.WithLength(82));
            
            return layout;
        }

        public IFixedLengthLayoutDescriptor FileControlLayout()
        {
            var layout = new FixedLayout<ICLReturnFileControlRecord>();
            if (UseRecordHeader)
            {
                layout.WithMember(c => c.RecordHeader, x => x.WithLength(4));
            }

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
               .WithMember(c => c.TotalRecords, x => x.WithLength(15))
               .WithMember(c => c.Reserved, x => x.WithLength(63));

            return layout;
        }

        public IFixedLengthLayoutDescriptor AccountHeaderLayout()
        {
            var layout = new FixedLayout<ICLReturnAccountHeaderRecord>();
           

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
            .WithMember(c => c.AccountNumber, x => x.WithLength(15))
            .WithMember(c => c.AccountName, x => x.WithLength(30))
            .WithMember(c => c.MasterAccountNumber, x => x.WithLength(15))
            .WithMember(c => c.Filler, x => x.WithLength(108));


            return layout;
        }

        public IFixedLengthLayoutDescriptor ReturnItemDetailLayout()
        {
            var layout = new FixedLayout<ICLReturnItemDetailRecord>();
            if (UseRecordHeader)
            {
                layout.WithMember(c => c.RecordHeader, x => x.WithLength(4));
            }

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
                .WithMember(c => c.CurrentSequenceNumber, x => x.WithLength(12))
                .WithMember(c => c.OriginalSequenceNumber, x => x.WithLength(12))
                .WithMember(c => c.Location, x => x.WithLength(10))
                .WithMember(c => c.ReturnType, x => x.WithLength(6))
                .WithMember(c => c.Disposition, x => x.WithLength(3))
                .WithMember(c => c.DepositDate, x => x.WithLength(8))
                .WithMember(c=>c.MICRRoutingNumber, x=> x.WithLength(9))
                .WithMember(c=>c.MICROnUs, x=>x.WithLength(15))
                .WithMember(c=>c.MICRAuxOnUs, x=>x.WithLength(10))
                .WithMember(c => c.Amount, x => x.WithLength(12).WithConverter(_decimalConverter))
                .WithMember(c => c.ReturnReasonCode, x => x.WithLength(4))
                .WithMember(c => c.ReturnReasonDescription, x => x.WithLength(20))
                .WithMember(c=> c.TimesRepresented, x=> x.WithLength(1))
                .WithMember(c=> c.RepresentEffectiveDate, x=>  x.WithLength(8))
                .WithMember(c => c.ACHCompanyId, x => x.WithLength(8))
                .WithMember(c=> c.ServiceFee, x=>x.WithLength(5).WithConverter(_decimalConverter))
                .WithMember(c=> c.ACHAdminReturnReasonCode, x=>x.WithLength(4))
                .WithMember(c=> c.ACHAdminReturnReasonDescription, x=>x.WithLength(10))
                .WithMember(c => c.Filler, x => x.WithLength(8));

            return layout;
        }
        public IFixedLengthLayoutDescriptor AddendumLayout()
        {
            var layout = new FixedLayout<ICLReturnItemAddendumRecord>();
            if (UseRecordHeader)
            {
                layout.WithMember(c => c.RecordHeader, x => x.WithLength(4));
            }

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
                .WithMember(c => c.CurrentSequenceNumber, x => x.WithLength(12))
                .WithMember(c => c.KeyFieldCode1, x => x.WithLength(3))
                .WithMember(c => c.KeyedFieldName1, x => x.WithLength(25))
                .WithMember(c => c.KeyedFieldData1, x => x.WithLength(25))
                .WithMember(c => c.KeyedFieldCode2, x => x.WithLength(3))
                .WithMember(c => c.KeyedFieldName2, x => x.WithLength(25))
                .WithMember(c=> c.KeyedFieldData2, x=>x.WithLength(25))
                .WithMember(c => c.Filler, x => x.WithLength(48)); 

            return layout;
        }

        public IFixedLengthLayoutDescriptor AccountControlLayout()
        {
            var layout = new FixedLayout<ICLReturnAccountControlRecord>();
            if (UseRecordHeader)
            {
                layout.WithMember(c => c.RecordHeader, x => x.WithLength(4));
            }

            layout.WithMember(c => c.RecordType, x => x.WithLength(2))
                .WithMember(c => c.TotalRecords, x => x.WithLength(5))
                .WithMember(c => c.TotalAmount, x => x.WithLength(10).WithConverter(_decimalConverter))
                .WithMember(c => c.BundleCount, x => x.WithLength(4))
                .WithMember(c => c.BundleAmount, x => x.WithLength(10).WithConverter(_decimalConverter))
                .WithMember(c => c.ReturnCount, x => x.WithLength(4))
                .WithMember(c => c.ReturnAmount, x => x.WithLength(10).WithConverter(_decimalConverter))
                .WithMember(c => c.Filler, x => x.WithLength(124));

            return layout;
        }
    }
}
