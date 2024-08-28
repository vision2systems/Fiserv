using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public class ICLBase: IICLRecord
    {


        public virtual byte[] RecordHeader
        {
            get => RecordLength.ToX9BigEndianFieldZero();
            
        }

        public string RecordType { get; set; }

        public virtual int RecordLength => 80;
    }

    public interface IICLRecord
    {
        
        string RecordType { get; set; }
        
    }
}
