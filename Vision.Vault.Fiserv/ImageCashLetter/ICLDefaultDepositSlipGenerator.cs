using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Text;
using BitMiracle.LibTiff.Classic;

namespace Vision.Vault.Fiserv.ImageCashLetter
{




    internal class ICLDefaultDepositSlipGenerator : IICLDepositSlipGenerator
    {
        public byte[] CreateDepositSlipFront(string accountNumber, DateTime date, decimal amount, string bankName)
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
                    graphics.DrawString($"Bank Name: {bankName}", font, brush, new PointF(50, 120));
                    graphics.DrawString($"Account Number: {accountNumber}", font, brush, new PointF(50, 170));
                    graphics.DrawString($"Date: {date:MM/dd/yyyy} ", font, brush, new PointF(50, 220));
                    graphics.DrawString($"Amount:  {amount:C2} ", font, brush, new PointF(50, 270));


                    // Add more details as needed...
                }

                using (var ms = new MemoryStream())
                {

                    SerializeBitmapToTiff6(bitmap, ms);
                    var bytes = ms.ToArray();
                    return bytes;
                    //using (var ms2 = new MemoryStream())
                    //{
                    //    using (Tiff output = Tiff.ClientOpen("in-memory", "w", ms2, new TiffStream()))
                    //    {


                    //        // Set TIFF tags
                    //        output.SetField(TiffTag.IMAGEWIDTH, width);
                    //        output.SetField(TiffTag.IMAGELENGTH, height);
                    //        output.SetField(TiffTag.BITSPERSAMPLE, 1);
                    //        output.SetField(TiffTag.SAMPLESPERPIXEL, 1);
                    //        output.SetField(TiffTag.ROWSPERSTRIP, height);
                    //        output.SetField(TiffTag.COMPRESSION, Compression.CCITTFAX4);
                    //        output.SetField(TiffTag.PHOTOMETRIC, Photometric.MINISWHITE);
                    //        output.SetField(TiffTag.FILLORDER, FillOrder.MSB2LSB);
                    //        output.SetField(TiffTag.XRESOLUTION, horizontalResolution);
                    //        output.SetField(TiffTag.YRESOLUTION, verticalResolution);
                    //        output.SetField(TiffTag.RESOLUTIONUNIT, ResUnit.INCH);
                    //        output.SetField(TiffTag.PLANARCONFIG, PlanarConfig.CONTIG);


                    //        // Write the image data
                    //        output.WriteScanline(bytes,0,0);

                    //        output.FlushData();
                    //    }

                    //    return ms2.ToArray();
                    //}
                }

            }
        }



        public byte[] CreateDepositSlipBack(string endorsedBy)
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
                    graphics.DrawString($"Endorsed by: {endorsedBy}", font, brush, new PointF(50, 75));
                    graphics.DrawString("Do not write, stamp, or sign below this line.", font, brush, new PointF(50, 120));
                    graphics.DrawLine(new Pen(Color.Black, 2), 5, 160, 1195, 160);

                    // Add more details as needed...
                }



                using (var ms = new MemoryStream())
                {

                    SerializeBitmapToTiff6(bitmap, ms);
                    var bytes = ms.ToArray();

                    return bytes;

                    //using(var ms2 = new MemoryStream())
                    //{
                    //    using (Tiff output = Tiff.ClientOpen("in-memory", "w", ms2, new TiffStream()))
                    //    {
                    //        // Set TIFF tags
                    //        output.SetField(TiffTag.IMAGEWIDTH, width);
                    //        output.SetField(TiffTag.IMAGELENGTH, height);
                    //        output.SetField(TiffTag.BITSPERSAMPLE, 1);
                    //        output.SetField(TiffTag.SAMPLESPERPIXEL, 1);
                    //        output.SetField(TiffTag.ROWSPERSTRIP, height);
                    //        output.SetField(TiffTag.COMPRESSION, Compression.CCITTFAX4);
                    //        output.SetField(TiffTag.FILLORDER, FillOrder.MSB2LSB);
                    //        output.SetField(TiffTag.XRESOLUTION, horizontalResolution);
                    //        output.SetField(TiffTag.YRESOLUTION, verticalResolution);
                    //        output.SetField(TiffTag.RESOLUTIONUNIT, ResUnit.INCH);
                    //        output.SetField(TiffTag.PLANARCONFIG, PlanarConfig.CONTIG);




                    //        // Write the image data
                    //        output.WriteScanline(bytes, 0, 0);

                    //        output.FlushData();
                    //    }

                    //    return ms2.ToArray();
                    //}

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
    }
}
