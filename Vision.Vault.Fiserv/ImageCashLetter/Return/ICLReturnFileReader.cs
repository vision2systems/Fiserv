using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Return
{
    public class ICLReturnFileReader
    {
        private bool UseRecordHeader = false;
        private int standardRecordLength = 80;
        private int standardImageRecordLength = 117;

        public int StandardRecordLength => UseRecordHeader ? standardRecordLength : standardRecordLength + 80;

        public ICLReturnFileReader()
        {

        }

        public
    }
}
