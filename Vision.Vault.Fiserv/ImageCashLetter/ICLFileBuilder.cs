using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FlatFiles;
using FlatFiles.TypeMapping;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLFileBuilder
    {
        private bool IsLastRecordAppended { get; set; }
        internal IICLDepositSlipGenerator DepositSlipGenerator { get; set; }






        internal ICLFileHeaderRecord Header { get; set; }

        internal List<ICLCashLetter> CashLetters { get; set; } = new List<ICLCashLetter>();



        internal ICLFileControlRecord FileControl { get; set; }


        internal List<IICLRecord> Records { get; set; } = new List<IICLRecord>();


        public ICLFileBuilder()
        {
            Header = new ICLFileHeaderRecord();

            Records.Add(Header);

            FileControl = new ICLFileControlRecord();
            SettlementDate = DateTime.UtcNow.AddDays(1);
            DepositSlipGenerator = new ICLDefaultDepositSlipGenerator();



        }

        public ICLFileBuilder(IICLDepositSlipGenerator depositSlipGenerator)
        {
            DepositSlipGenerator = depositSlipGenerator;
        }

        public DateTime SettlementDate { get; set; }


        public bool IsTestFile
        {
            get => Header.TestFileIndicator == "T";
            set => Header.TestFileIndicator = value ? "T" : "P";
        }

        /// <summary>
        /// Name of the organization that is creating the file that is used in the file name
        /// </summary>
        public string CustomerName { get; set; }

        public string DepositAccountNumber { get; set; }


        public string ImmediateDestinationRoutingNumber
        {
            get => Header.ImmediateDestinationRoutingNumber;
            set => Header.ImmediateDestinationRoutingNumber = value;
        }

        public string ImmediateOriginRoutingNumber
        {
            get => Header.ImmediateOriginRoutingNumber;
            set => Header.ImmediateOriginRoutingNumber = value;
        }

        public string ImmediateOriginName
        {
            get => Header.ImmediateOriginName;
            set => Header.ImmediateOriginName = value;
        }

        public string ImmediateDestinationName
        {
            get => Header.ImmediateDestinationName;
            set => Header.ImmediateDestinationName = value;
        }


        public string ContactName
        {
            get => FileControl.ContactName;
            set => FileControl.ContactName = value;
        }

        public string ContactPhoneNumber
        {
            get => FileControl.ContactPhoneNumber;
            set => FileControl.ContactPhoneNumber = value;
        }



        public DateTime FileDate
        {
            get => Header.FileDate;
            set => Header.FileDate = value;
        }

        public decimal TotalAmount
        {
            get => FileControl.TotalAmount;
            internal set => FileControl.TotalAmount = value;
        }

        public int ItemCount
        {
            get => FileControl.TotalItemCount;
            internal set => FileControl.TotalItemCount = value;
        }





        public ICLCashLetterBuilder CreateCashLetter(long cashLetterId)
        {
            return new ICLCashLetterBuilder(this, cashLetterId, Header.ImmediateOriginRoutingNumber, FileDate);
        }

        internal void CompleteFile()
        {
            if (!IsLastRecordAppended)
            {
                FileControl.ContactName = ContactName;
                FileControl.ContactPhoneNumber = ContactPhoneNumber;
                FileControl.TotalAmount = CashLetters.Sum(s => s.Control.TotalAmount);
                FileControl.TotalItemCount = CashLetters.Sum(s => s.Control.ItemCount);
                FileControl.TotalRecordCount = Records.Count() + 1;//one more record after this record is added
                FileControl.CashLetterCount = CashLetters.Count();
                FileControl.Reserved = "".PadLeft(15, ' ');

                Records.Add(FileControl);
                IsLastRecordAppended = true;
            }
        }








    }
}
