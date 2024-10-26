using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLFile
    {
        internal ICLCashLetterHeaderRecord Header { get; set; } = new ICLCashLetterHeaderRecord();
        internal ICLCashLetterControlRecord Control { get; set; } = new ICLCashLetterControlRecord();

        internal List<ICLBundle> Bundles { get; set; } = new List<ICLBundle>();
    }
}
