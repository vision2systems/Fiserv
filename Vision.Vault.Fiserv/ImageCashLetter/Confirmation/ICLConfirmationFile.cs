using System;
using System.Collections.Generic;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record;

namespace Vision.Vault.Fiserv.ImageCashLetter.Confirmation
{
    public class ICLConfirmationFile
    {
        public ICLConfirmationFileHeader Header { get; set; }
        public ICLConfirmationFileControl Control { get; set; }

        public List<ICLConfirmationCashLetterDeposit> CashLetterDeposits { get; set; } = new List<ICLConfirmationCashLetterDeposit>();
    }
}
