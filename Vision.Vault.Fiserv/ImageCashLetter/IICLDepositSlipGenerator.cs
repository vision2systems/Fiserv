using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter
{
    public interface IICLDepositSlipGenerator
    {
        byte[] CreateDepositSlipFront(string accountNumber, DateTime date, decimal amount, string bankName);

        byte[] CreateDepositSlipBack(string endorsedBy);
    }
}
