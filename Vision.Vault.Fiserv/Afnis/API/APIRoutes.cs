using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.Vault.Treasury.Afnis.API
{
    public class AfinisAPIRoutes
    {
        public string ACHDebit => "payments/ach/debit";
        public string ACHCredit => "payments/ach/credit";

        public string ACHTransactionStatusByTransactionId => "payments/ach/status/transactionid";

        public string ACHTransactionStatusByInstructionId => "payments/ach/status/instructionid";

        public string ACHReturns => "/ret";

        public string AccountValidationDebit => "accounts/validate/achPaymentDebitAcceptance";
        public string AccountValidationCredit => "accounts/validate/achPaymentCreditAcceptance";

        public string AccountValidateOwnership => "validatewithname";    

    }
}
