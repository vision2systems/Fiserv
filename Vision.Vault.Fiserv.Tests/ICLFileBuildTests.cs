using FlatFiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using Vision.Vault.Fiserv.ImageCashLetter;
using System.Text;

namespace Vision.Vault.Fiserv.Tests
{
    [TestClass]
    public class ICLFileBuildTests
    {

        [TestMethod]
        public void TestFieldZeroLogic()
        {
            var test = 2249;
            var littleEndianBytes = BitConverter.GetBytes(test);

            var bigEndianBytes = test.ToX9BigEndianFieldZero();
            var convertedString = BitConverter.ToString(bigEndianBytes);
            Console.WriteLine(convertedString);

            var testString = Encoding.ASCII.GetString(bigEndianBytes);
           
            var testBytes = Encoding.ASCII.GetBytes(testString);
            
            
            var toValidate = testBytes.FromX9BigEndianFieldZero();
            Assert.IsTrue(toValidate == test);



        }


        [TestMethod]
        public void CanWeInitializeAFile()
        {
            var builder = new ICLFileBuilder();
            Assert.IsNotNull(builder);
        }

        [TestMethod]
        public void EnsureBundleControlRecordLength()
        {
            var bundleControlRecord = new ICLBundleControlRecord();
            var fixedFileOptions = new FixedLengthOptions()
            {
                HasRecordSeparator = false,
                FillCharacter = ' '
            };

            var fileBuilder = new ICLFileBuilder();
            var serializer = new FiservICLFileSerializer();

            
            using(var ms = new MemoryStream())
            {
                using (TextWriter writer = new StreamWriter(ms))
                {
                    var bcw = serializer.BundleControlMapper.GetWriter(writer, fixedFileOptions);
                    bcw.Write(bundleControlRecord);
                }

                var bytes = ms.ToArray();
                Assert.AreEqual(80, ms.Length);
            }
        }



        [TestMethod]
        public void CanWeCreateACashLetterAndABundle()
        {
            var fileBuilder = new ICLFileBuilder();

            fileBuilder.ImmediateDestinationRoutingNumber = "999944442";
            fileBuilder.DepositAccountNumber = "11111111111";
            fileBuilder.ImmediateOriginRoutingNumber = "111017979";
            fileBuilder.ContactName = "Joe Smith";
            fileBuilder.ContactPhoneNumber = "2145551212";
            fileBuilder.FileDate = DateTime.UtcNow;
            fileBuilder.ImmediateDestinationName = "Texas Capital";
            fileBuilder.ImmediateOriginName = "TESTCompany";
            fileBuilder.CustomerName = "Test";


            Assert.IsNotNull(fileBuilder);
            using (var cashLetter = fileBuilder.CreateCashLetter(1))
            {
                Assert.IsNotNull(cashLetter);
                using (var bundle = cashLetter.CreateBundle(1,1))
                {
                    Assert.IsNotNull(bundle);
                    var frontImage = new byte[1024];
                    var backImage = new byte[1024];
                    bundle.AddDepositWithCheckImages(100,"111000614","1111111111","0101",null,frontImage, backImage, 1, DateTime.UtcNow);
                }
            }

            var serializer = new FiservICLFileSerializer();
            var fileName = serializer.GetFileName(fileBuilder);

            
            Assert.IsNotNull(fileName);

            var bytes = serializer.Serialize(fileBuilder);

            Assert.IsNotNull(bytes);

            File.WriteAllBytes("C:\\testoutput\\{fileName}", bytes);
        }


        [TestMethod]
        public void BuildDepositSlipFrontTiff()
        {
            var depositSlip = CreateDepositSlip("11111111", DateTime.UtcNow, 100);

            File.WriteAllBytes("C:\\dev\\DepositSlipFront.tiff",depositSlip);
        }

        [TestMethod]
        public void BuildDepositSlipBackTiff()
        {
            var depositSlip = CreateDepositSlipBack();

            File.WriteAllBytes("C:\\dev\\DepositSlipBack.tiff", depositSlip);
        }

        

        private byte[] CreateDepositSlip(string accountNumber, DateTime date, decimal amount)
        {
            // Define the size of the deposit slip
            int width = 1200;
            int height = 550;
            float horizontalResolution = 200.0f;
            float verticalResolution = 200.0f;

            // Create a bitmap
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                bitmap.SetResolution(horizontalResolution, verticalResolution);
                // Create graphics from the bitmap
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    // Set background color
                    graphics.Clear(Color.White);

                    // Define font and brush
                    Font font = new Font("Arial", 14);
                    Brush brush = Brushes.Black;

                    // Draw deposit slip elements
                    graphics.DrawString("Deposit Slip", new Font("Arial", 18, FontStyle.Bold), brush, new PointF(300, 50));
                    graphics.DrawString($"Bank Name: TEST", font, brush, new PointF(50, 120));
                    graphics.DrawString($"Account Number: {accountNumber}", font, brush, new PointF(50, 170));
                    graphics.DrawString($"Date: {date:MM/dd/yyyy} ", font, brush, new PointF(50, 220));
                    graphics.DrawString($"Amount:  {amount:C2} ", font, brush, new PointF(50, 270));
                    

                    // Add more details as needed...
                }

                using (var ms = new MemoryStream())
                {
                    
                    SerializeBitmapToTiff6(bitmap, ms);
                    return ms.ToArray();
                }

            }
        }
     


        


        private void SerializeBitmapToTiff6(Bitmap bitmap, MemoryStream ms)
        {
            FrameDimension frameDimension = new FrameDimension(bitmap.FrameDimensionsList[0]);

            // Create a new EncoderParameters object
            ImageCodecInfo tiffCodec = GetEncoderInfo("image/tiff");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);

         

            bitmap.Save(ms, tiffCodec, encoderParams);
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == mimeType)
                {
                    return codec;
                }
            }
            return null;
        }

        private byte[] CreateDepositSlipBack()
        {
            // Define the size of the deposit slip
            int width = 1200;
            int height = 550;
            float horizontalResolution = 200.0f;
            float verticalResolution = 200.0f;

            // Create a bitmap
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                bitmap.SetResolution(horizontalResolution, verticalResolution);
                // Create graphics from the bitmap
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    // Set background color
                    // Set background color
                    graphics.Clear(Color.White);


                    // Draw back side elements (e.g., instructions, endorsements, etc.)
                    Font font = new Font("Arial", 12);
                    Brush brush = Brushes.Black;
                    graphics.DrawString("Endorsed by: TEST", font, brush, new PointF(50, 75));
                    graphics.DrawString("Do not write, stamp, or sign below this line.", font, brush, new PointF(50, 120));
                    graphics.DrawLine(new Pen(Color.Black,2),5,160,1195,160);

                    // Add more details as needed...
                }




                using (var ms = new MemoryStream())
                {

                    SerializeBitmapToTiff6(bitmap, ms);
                    return ms.ToArray();
                }

            }


        }
    }
}
