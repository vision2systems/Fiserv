using System;
using System.Collections.Generic;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record;

namespace Vision.Vault.Fiserv.ImageCashLetter.Confirmation
{
    public class ICLConfirmationCashLetterDeposit
    {
        public ICLConfirmationCashLetterDepositHeader Header { get; set; }
        public ICLConfirmationCashLetterDepositControl Control { get; set; }
        public List<ICLConfirmationBundleDetail> Bundles { get; set; }
    }
}
