using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record
{
    public class ICLConfirmationFileControl : ICLBase
    {
        public int TotalRecords { get; set; }   

        public string Reserved { get; set; }

        public string OriginalRecord { get; set; }
    }
}
