using FluentFiles.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Vision.Vault.Fiserv.ImageCashLetter.Confirmation.Record;
using Vision.Vault.Fiserv.ImageCashLetter.Return.Record;

namespace Vision.Vault.Fiserv.ImageCashLetter.Return
{
    public class ReturnMasterDetailStrategy : IMasterDetailStrategy
    {
        private ICLReturnFile _returnFile = new ICLReturnFile();
        private ICLReturnAccount _currentAccount = null;
        private ICLReturnItemDetailRecord _currentDetail = null;

        public ReturnMasterDetailStrategy()
        {

        }

        public bool Handle(object record)
        {
            if(record.GetType() == typeof(ICLReturnItemAddendumRecord))
            {
                _currentDetail.Addendums.Add((ICLReturnItemAddendumRecord)record);
                return true;
            }

            if(record.GetType() == typeof(ICLReturnItemDetailRecord))
            {
                _currentDetail = (ICLReturnItemDetailRecord)record;
                _currentAccount.Returns.Add(_currentDetail);
                return true;
            }

            if(record.GetType() == typeof(ICLReturnAccountControlRecord))
            {
                _currentAccount.Control = (ICLReturnAccountControlRecord)record;
                return true;
            }   

            if(record.GetType() == typeof(ICLReturnAccountHeaderRecord))
            {
                _currentAccount = new ICLReturnAccount();
                _currentAccount.Header = (ICLReturnAccountHeaderRecord)record;
                _returnFile.Accounts.Add(_currentAccount);
                return true;
            }

            if(record.GetType() == typeof(ICLReturnFileHeaderRecord))
            {
                _returnFile.Header = (ICLReturnFileHeaderRecord)record;
                return true;
            }

            if(record.GetType() == typeof(ICLReturnFileControlRecord))
            {
                _returnFile.Control = (ICLReturnFileControlRecord)record;
                return true;
            }

            return false;

    }
}
