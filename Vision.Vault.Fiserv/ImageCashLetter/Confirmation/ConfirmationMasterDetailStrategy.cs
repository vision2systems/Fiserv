using FluentFiles.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record;

namespace Vision.Vault.Fiserv.ImageCashLetter.Confirmation
{
    public class ConfirmationMasterDetailStrategy : IMasterDetailStrategy
    {
        
        private ICLConfirmationCashLetterDeposit _currentDeposit;
        private ICLConfirmationFile _file = new ICLConfirmationFile();

        public ICLConfirmationFile ConfirmationFile         {
            get
            {
                return _file;
            }
        }


        

        public bool Handle(object record)
        {
            if (record.GetType() == typeof(ICLConfirmationBundleDetail))
            {
                _currentDeposit.Bundles.Add((ICLConfirmationBundleDetail)record);
                return true;

            }

            if (record.GetType() == typeof(ICLConfirmationCashLetterDepositHeader))
            {
                _currentDeposit = new ICLConfirmationCashLetterDeposit();
                _currentDeposit.Header = (ICLConfirmationCashLetterDepositHeader)record;
                _file.CashLetterDeposits.Add(_currentDeposit);
                return true;
            }

            if(record.GetType() == typeof(ICLConfirmationCashLetterDepositControl))
            {
                _currentDeposit.Control = (ICLConfirmationCashLetterDepositControl)record;
                return true;
            }

            if(record.GetType() == typeof(ICLConfirmationFileHeader))
            {
                _file.Header = (ICLConfirmationFileHeader)record;
                return true;

            }

            if (record.GetType() == typeof(ICLConfirmationFileControl))
            {
                _file.Control = (ICLConfirmationFileControl)record;
                return true;

            }

            return false;


        }

    }
}
