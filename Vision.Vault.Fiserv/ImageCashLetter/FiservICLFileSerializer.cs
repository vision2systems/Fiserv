using FlatFiles.TypeMapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FlatFiles;
using System.Linq;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    internal static class FixedLengthTypeMapperExtensions
    {
        internal static int WriteToStream<TRecordType>(this IFixedLengthTypeMapper<TRecordType> mapper, IICLRecord record, StreamWriter sw, Encoding encoding, FixedLengthOptions options) where TRecordType : class
        {
            var toWrite = record as TRecordType;


            using (var ms = new MemoryStream())
            {
                using (var tw = new StreamWriter(ms, encoding))
                {
                    var fhw = mapper.GetWriter(tw, options);
                    fhw.Write(toWrite);

                }

                var bytes = ms.ToArray();
                sw.BaseStream.Write(bytes, 0, bytes.Length);
                return bytes.Length;

            }

        }
    }




    public class FiservICLFileSerializer
    {
        public bool UseEBCIDICEncoding { get; set; }
        public bool UseFieldZero { get; set; }




        public IFixedLengthTypeMapper<ICLFileHeaderRecord> FileHeaderMapper;
        public IFixedLengthTypeMapper<ICLCashLetterHeaderRecord> CashLetterHeaderMapper;
        public IFixedLengthTypeMapper<ICLBundleHeaderRecord> BundleHeaderMapper;

        public IFixedLengthTypeMapper<ICLCheckDetailRecord> CheckDetailMapper;
        public IFixedLengthTypeMapper<ICLImageViewDetailRecord> ImageViewDetailMapper;
        public IFixedLengthTypeMapper<ICLImageRecord> ImageViewMapper;
        public IFixedLengthTypeMapper<ICLBundleControlRecord> BundleControlMapper;
        public IFixedLengthTypeMapper<ICLCashLetterControlRecord> CashLetterControlMapper;
        public IFixedLengthTypeMapper<ICLFileControlRecord> FileControlMapper;


        public FiservICLFileSerializer()
        {
            UseEBCIDICEncoding = false;
            UseFieldZero = true;


        }


        internal void InitializeMapperForFileHeader()
        {

            var mapper = FixedLengthTypeMapper.Define<ICLFileHeaderRecord>();
            if (UseFieldZero)
                mapper.Property(x => x.RecordHeader, 4);

            mapper.Property(x => x.RecordType, 2);
            mapper.Property(x => x.StandardLevel, 2);
            mapper.Property(x => x.TestFileIndicator, 1);
            mapper.Property(x => x.ImmediateDestinationRoutingNumber, 9);
            mapper.Property(x => x.ImmediateOriginRoutingNumber, 9);
            mapper.Property(x => x.FileDate, 12).OutputFormat("yyyyMMddHHmm");
            mapper.Property(x => x.ResendIndicator, 1);
            mapper.Property(x => x.ImmediateDestinationName, 18);
            mapper.Property(x => x.ImmediateOriginName, 18);
            mapper.Property(x => x.FileModifier, 1);
            mapper.Property(x => x.CountryCode, 2);
            mapper.Property(x => x.UserField, 4);
            mapper.Property(x => x.Reserved, 1);

            FileHeaderMapper = mapper;

        }

        internal void InitializeMapperForCashLetterHeader()
        {

            var mapper = FixedLengthTypeMapper.Define<ICLCashLetterHeaderRecord>();
            if (UseFieldZero)
                mapper.Property(x => x.RecordHeader, 4);

            mapper.Property(x => x.RecordType, 2);
            mapper.Property(x => x.CollectionTypeIndicator, 2);
            mapper.Property(x => x.DestinationRoutingNumber, 9);
            mapper.Property(x => x.ECEInstitituionRoutingNumber, 9);
            mapper.Property(x => x.BusinessDate, 8).OutputFormat("yyyyMMdd");
            mapper.Property(x => x.CreationDate, 12).OutputFormat("yyyyMMddHHmm");
            mapper.Property(x => x.CashLetterRecordTypeIndicator, 1);
            mapper.Property(x => x.CashLetterDocumentTypeIndicator, 1);
            mapper.Property(x => x.CashLetterId, 8).OutputFormat("D8");
            mapper.Property(x => x.ContactName, 14);
            mapper.Property(x => x.ContactPhone, 10);
            mapper.Property(x => x.FedWorkType, 1);
            mapper.Property(x => x.UserField, 2);
            mapper.Property(x => x.Reserved, 1);


            CashLetterHeaderMapper = mapper;

        }


        internal void InitializeMapperForBundleHeader()
        {

            var mapper = FixedLengthTypeMapper.Define<ICLBundleHeaderRecord>();
            if (UseFieldZero)
                mapper.Property(x => x.RecordHeader, 4);

            mapper.Property(x => x.RecordType, 2);
            mapper.Property(x => x.CollectionTypeIndicator, 2);
            mapper.Property(x => x.DestinationRoutingNumber, 9);
            mapper.Property(x => x.ECEInstituionRoutingNumber, 9);
            mapper.Property(x => x.BusinessDate, 8).OutputFormat("yyyyMMdd");
            mapper.Property(x => x.CreationDate, 8).OutputFormat("yyyyMMdd");
            mapper.Property(x => x.BundleId, 10).OutputFormat("D11");
            mapper.Property(x => x.SequenceNumber, 4).OutputFormat("D3");
            mapper.Property(x => x.CycleNumber, 2).OutputFormat("D2");
            mapper.Property(x => x.Reserved, 26);


            BundleHeaderMapper = mapper;

        }





        internal void InitializeMapperForCheckDetailRecord()
        {

            var mapper = FixedLengthTypeMapper.Define<ICLCheckDetailRecord>();
            if (UseFieldZero)
                mapper.Property(x => x.RecordHeader, 4);

            mapper.Property(x => x.RecordType, 2);
            mapper.Property(x => x.AuxOnUs, 15).OnFormatting((x, y) => ((string)y ?? "").PadLeft(15, ' '));
            mapper.Property(x => x.ExternalProcessingCode, 1);
            mapper.Property(x => x.PayorBankRoutingNumber, 9);
            mapper.Property(x => x.OnUs, 20).OnFormatting((x, y) => ((string)y ?? "").PadLeft(20, ' '));
            mapper.Property(x => x.Amount, 10).OnFormatting((x, y) => (decimal)y * 100).OutputFormat("0000000000");
            mapper.Property(x => x.ECEInstitutionItemSequenceNumber, 15).OutputFormat("D15");
            mapper.Property(x => x.DocumentTypeIndicator, 1);
            mapper.Property(x => x.ReturnAcceptanceIndicator, 1);
            mapper.Property(x => x.MICRValidIndicatorIgnore, 1);
            //mapper.Property(x => x.MICRValidIndicator, 1);
            mapper.Property(x => x.BOFDIndicator, 1);
            mapper.Property(x => x.CheckDetailRecordAddendumCount, 2).OutputFormat("D2");
            mapper.Property(x => x.CorrectionIndicator, 1);
            mapper.Property(x => x.ArchiveTypeIndicator, 1);

            CheckDetailMapper = mapper;

        }


        internal void InitializeMapperForImageDetailView()
        {

            var mapper = FixedLengthTypeMapper.Define<ICLImageViewDetailRecord>();

            if (UseFieldZero)
                mapper.Property(x => x.RecordHeader, 4);


            mapper.Property(x => x.RecordType, 2);
            mapper.Property(x => x.ImageIndicator, 1);
            mapper.Property(x => x.ImageCreatorRoutingNumber, 9);
            mapper.Property(x => x.ImageCreationDate, 8).OutputFormat("yyyyMMdd");
            mapper.Property(x => x.ImageViewFormat, 2);
            mapper.Property(x => x.ImageViewCompressionAlgorithm, 2);
            mapper.Property(x => x.ImageViewDataSize, 7).OutputFormat("D7");
            mapper.Property(x => x.ViewSide, 1);
            mapper.Property(x => x.ViewDescriptor, 2);
            mapper.Property(x => x.DigitalSignatureIndicator, 1);
            mapper.Property(x => x.DigitalSignatureMethod, 2);
            mapper.Property(x => x.SecurityKeySize, 5);
            mapper.Property(x => x.StartOfProtectedData, 7);
            mapper.Property(x => x.LengthOfProtectedData, 7);
            mapper.Property(x => x.ImageReCreateIndicator, 1);
            mapper.Property(x => x.UserField, 8);
            mapper.Property(x => x.Reserved, 15);


            ImageViewDetailMapper = mapper;

        }


        internal void InitializeMapperForImageView()
        {

            var mapper = FixedLengthTypeMapper.Define<ICLImageRecord>();

            //because the field zero for variable length records can be a non ascii encodable value
            //we do not use the Fixed Field Mapper to output the record header.
            //instead we do it as part of the serialization and write those bytes just as we do the images
            //without the encoding
            //if (UseFieldZero)
            //    mapper.Property(x => x.RecordHeader, 4);

            mapper.Property(x => x.RecordType, 2);//1-2
            mapper.Property(x => x.ECEInstitutionRoutingNumber, 9);//3-11
            mapper.Property(x => x.BundleBusinessDate, 8).OutputFormat("yyyyMMdd"); //12-19
            mapper.Property(x => x.CycleNumber, 2); //20-21
            mapper.Property(x => x.ECEItemSequenceNumber, 15).OutputFormat("D15"); //22-36
            mapper.Property(x => x.SecurityOriginatorName, 16); //37-52
            mapper.Property(x => x.SecurityAuthenticatorName, 16); //53-68
            mapper.Property(x => x.SecurityKeyName, 16);//69-80
            mapper.Property(x => x.ClippingOrigin, 1);//85
            mapper.Property(x => x.ClippingCoordinateH1, 4);//86-89
            mapper.Property(x => x.ClippingCoordinateH2, 4);//90-93
            mapper.Property(x => x.ClippingCoordinateV1, 4);//94-97
            mapper.Property(x => x.ClippingCoordinateV2, 4);//98-101
            mapper.Property(x => x.LengthOfImageReferenceKey, 4).OutputFormat("D4");//102-105
            mapper.Property(x => x.LengthOfDigitalSignature, 5);//106-110
            mapper.Property(x => x.LengthOfImageData, 7).OutputFormat("D7");//111-117


            //image data is handled in the file writer directly



            ImageViewMapper = mapper;

        }

        internal void InitializeMapperForBundleControlRecord()
        {

            var mapper = FixedLengthTypeMapper.Define<ICLBundleControlRecord>();
            if (UseFieldZero)
                mapper.Property(x => x.RecordHeader, 4);

            mapper.Property(x => x.RecordType, 2);
            mapper.Property(x => x.ItemCount, 4).OutputFormat("D4");
            mapper.Property(x => x.TotalAmount, 12).OnFormatting((x, y) => (decimal)y * 100).OutputFormat("000000000000");
            mapper.Property(x => x.MICRValidTotalAmountBlank, 12);
            //mapper.Property(x => x.MICRValidTotalAmount, 12).OnFormatting((x, y) => (decimal)y * 100).OutputFormat("000000000000");
            mapper.Property(x => x.ImagesWithinBundleCount, 5).OutputFormat("D5");
            mapper.Property(x => x.UserField, 20);
            //mapper.Property(x => x.CreditTotalIndicator, 1);
            mapper.Property(x => x.Reserved, 25);


            BundleControlMapper = mapper;

        }

        internal void InitializeMapperForCashLettterControlRecord()
        {

            var mapper = FixedLengthTypeMapper.Define<ICLCashLetterControlRecord>();
            if (UseFieldZero)
                mapper.Property(x => x.RecordHeader, 4);

            mapper.Property(x => x.RecordType, 2);
            mapper.Property(x => x.BundleCount, 6).OutputFormat("D6");
            mapper.Property(x => x.ItemCount, 8).OutputFormat("D8");
            mapper.Property(x => x.TotalAmount, 14).OnFormatting((x, y) => (decimal)y * 100).OutputFormat("00000000000000");
            mapper.Property(x => x.ImageCount, 9).OutputFormat("D9");
            mapper.Property(x => x.ECEInstitutionName, 18);
            mapper.Property(x => x.SettlementDate, 8).OutputFormat("yyyyMMdd");
            mapper.Property(x => x.Reserved, 15);


            CashLetterControlMapper = mapper;

        }


        internal void InitializeMapperForFileControlRecord()
        {

            var mapper = FixedLengthTypeMapper.Define<ICLFileControlRecord>();
            if (UseFieldZero)
                mapper.Property(x => x.RecordHeader, 4);

            mapper.Property(x => x.RecordType, 2);
            mapper.Property(x => x.CashLetterCount, 6).OutputFormat("D6");
            mapper.Property(x => x.TotalRecordCount, 8).OutputFormat("D8");
            mapper.Property(x => x.TotalItemCount, 8).OutputFormat("D8");
            mapper.Property(x => x.TotalAmount, 16).OnFormatting((x, y) => (decimal)y * 100).OutputFormat("0000000000000000");
            mapper.Property(x => x.ContactName, 14);
            mapper.Property(x => x.ContactPhoneNumber, 10);
            //mapper.Property(x => x.TotalFileCreditAmount, 16).OnFormatting((x, y) => (decimal)y * 100).OutputFormat("0000000000000000");
            mapper.Property(x => x.Reserved, 16);



            FileControlMapper = mapper;

        }

        public void InitializeMappers()
        {
            InitializeMapperForFileHeader();
            InitializeMapperForFileControlRecord();
            InitializeMapperForCashLetterHeader();
            InitializeMapperForBundleHeader();
            InitializeMapperForCheckDetailRecord();
            InitializeMapperForImageDetailView();
            InitializeMapperForImageView();
            InitializeMapperForBundleControlRecord();
            InitializeMapperForCashLettterControlRecord();
            InitializeMapperForFileControlRecord();


        }

        public string GetFileName(ICLFileBuilder fileBuilder)
        {
            var formattedDate = fileBuilder.FileDate.ToString("yyyyMMddHHmmss");
            return $"{fileBuilder.ImmediateOriginRoutingNumber}.DEP.{fileBuilder.CustomerName}.{formattedDate}.DAT";
        }

        private class SerializedImageReference
        {
            public int Start { get; set; }
            public int End { get; set; }

            public byte[] Original { get; set; }
            public byte[] RecordHeader { get; set; }
        }



        public byte[] Serialize(ICLFileBuilder builder)
        {
            builder.CompleteFile();

            InitializeMappers();

            var index = 0;
            var encoding = Encoding.ASCII;
            var targetTotalLength = 0;
            //ICLImageRecord firstImage = null;
            //var firstImageRecordStart = 0;
            var standardRecordLength = 80;
            var imageRecordLength = 117;


            var imageReferences = new List<SerializedImageReference>();


            if (UseEBCIDICEncoding)
                encoding = Encoding.GetEncoding(37);

            var fixedFileOptions = new FixedLengthOptions()
            {
                HasRecordSeparator = false,
                FillCharacter = ' ',
            };

            if (UseFieldZero)
            {
                standardRecordLength += 4;
                imageRecordLength += 4;
            }


            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {

                    foreach (var record in builder.Records)
                    {
                        index++;
                        switch (record.RecordType)
                        {
                            case "01":

                                FileHeaderMapper.WriteToStream(record, sw, encoding, fixedFileOptions);
                                targetTotalLength += standardRecordLength;

                                break;
                            case "10":


                                CashLetterHeaderMapper.WriteToStream(record, sw, encoding, fixedFileOptions);
                                targetTotalLength += standardRecordLength;


                                break;
                            case "20":


                                BundleHeaderMapper.WriteToStream(record, sw, encoding, fixedFileOptions);

                                targetTotalLength += standardRecordLength;

                                break;
                            case "25":


                                CheckDetailMapper.WriteToStream(record, sw, encoding, fixedFileOptions);
                                targetTotalLength += standardRecordLength;

                                break;
                            case "50":


                                ImageViewDetailMapper.WriteToStream(record, sw, encoding, fixedFileOptions);

                                targetTotalLength += standardRecordLength;

                                break;
                            case "52":

                                var iv = record as ICLImageRecord;
                                //because field zero can be a non ascii encodable value e.g. 2449
                                //has a byte value in the last byte of 201 which is not a valid ascii value
                                //
                                //so we do not use the ascii encoder to output the field zero value
                                //it works for standard record type because hex of 50 = int 80 is in the ascii table
                                if (UseFieldZero)
                                {
                                    sw.BaseStream.Write(iv.RecordHeader, 0, 4);

                                }

                                ImageViewMapper.WriteToStream(iv, sw, encoding, fixedFileOptions);


                                var recordLength = iv.RecordHeader.FromX9BigEndianFieldZero();
                                if (recordLength != iv.RecordLength)
                                    throw new Exception("record length is not correct");

                                targetTotalLength += imageRecordLength;
                                var ir = new SerializedImageReference();
                                ir.Start = (int)sw.BaseStream.Position;
                                ir.RecordHeader = iv.RecordHeader;

                                sw.BaseStream.Write(iv.ImageData, 0, iv.ImageData.Length);

                                targetTotalLength += iv.LengthOfImageData;
                                ir.End = ir.Start + iv.ImageData.Length;
                                ir.Original = iv.ImageData;
                                imageReferences.Add(ir);


                                break;
                            case "70":


                                BundleControlMapper.WriteToStream(record, sw, encoding, fixedFileOptions);

                                targetTotalLength += standardRecordLength;

                                break;
                            case "90":

                                CashLetterControlMapper.WriteToStream(record, sw, encoding, fixedFileOptions);
                                targetTotalLength += standardRecordLength;



                                break;

                            case "99":


                                FileControlMapper.WriteToStream(record, sw, encoding, fixedFileOptions);
                                targetTotalLength += standardRecordLength;

                                break;
                            default:
                                throw new NotImplementedException();

                        }


                    }




                    var bytes = ms.ToArray();

                    var length = bytes.Length;
                    if (length != targetTotalLength)
                    {

                        throw new Exception();


                    }

                    //added to verify images are binary matches not necessary for production
                    foreach (var ir in imageReferences)
                    {
                        var serializedBytes = new byte[ir.Original.Length];
                        Array.Copy(bytes, ir.Start, serializedBytes, 0, ir.Original.Length);


                        if (!serializedBytes.SequenceEqual(ir.Original))
                            throw new Exception("not an exact binary match for tiff image");

                    }


                    return bytes;


                }

            }

        }


        public void WriteAllImagesToDirectory(string directory, ICLFileBuilder builder)
        {
            var index = 0;
            foreach (var r in builder.Records)
            {
                index++;
                if (r.RecordType == "52")
                {
                    var iv = r as ICLImageRecord;
                    var fileName = $"{index}.{iv.ECEItemSequenceNumber}.TIFF";
                    var path = Path.Combine(directory, fileName);
                    File.WriteAllBytes(path, iv.ImageData);

                }
            }
        }
    }
}
