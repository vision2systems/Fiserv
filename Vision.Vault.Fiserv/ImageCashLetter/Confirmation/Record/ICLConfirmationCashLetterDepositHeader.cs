using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record
{
    public class ICLConfirmationCashLetterDepositHeader : ICLBase
    {
        public string FileReceiveDate { get; set; }
        public string CashLetterId { get; set; }
        public string Reserved { get; set; }
        public string OriginalRecord { get; set; }
    }
}
