using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    internal class ICLBundle
    {
        internal ICLBundleHeaderRecord BundleHeader { get; set; } = new ICLBundleHeaderRecord();
        internal ICLBundleControlRecord BundleControl { get; set; } = new ICLBundleControlRecord();
        internal List<IICLRecord> Records { get; set; } = new List<IICLRecord>();

        internal int RecordType25Count { get; set; }

        internal int ImageCount { get; set; }

        internal decimal TotalAmount { get; set; }

        internal decimal MICRValidTotalAmount { get; set; }
    }
}
