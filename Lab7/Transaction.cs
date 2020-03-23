using System;

namespace Lab7
{
    public class Transaction
    {
        private bool _isMade = false;
        public IAccount AccountToAdd { get; private set; }
        public IAccount AccountToDec { get; private set; }
        public double Amount { get; private set; }

        private Transaction() {}
        
        public bool TryMake()
        {
            if (_isMade)
                return false;
            
            var addSnapshot = AccountToAdd?.CreateSnapshot();
            var decSnapshot = AccountToDec?.CreateSnapshot();
            try
            {
                AccountToAdd?.Add(Amount);
                AccountToDec?.Dec(Amount);
                _isMade = true;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                AccountToAdd?.Revert(addSnapshot);
                AccountToDec?.Revert(decSnapshot);
                return false;
            }
        }

        public bool TryRevert()
        {
            if (!_isMade)
                return false;
            
            var addSnapshot = AccountToAdd?.CreateSnapshot();
            var decSnapshot = AccountToDec?.CreateSnapshot();
            try
            {
                AccountToAdd?.Dec(Amount);
                AccountToDec?.Add(Amount);
                _isMade = false;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                AccountToAdd?.Revert(addSnapshot);
                AccountToDec?.Revert(decSnapshot);
                return false;
            }
        }

        public class TransactionBuilder
        {
            private double _maxAmountForNonTrusted;
            private readonly Transaction _transaction = new Transaction();

            public TransactionBuilder(double maxAmountForNonTrusted)
            {
                _maxAmountForNonTrusted = maxAmountForNonTrusted;
            }

            public TransactionBuilder Add(IAccount account)
            {
                _transaction.AccountToAdd = account;

                return this;
            }

            public TransactionBuilder Dec(IAccount account)
            {
                _transaction.AccountToDec = account;

                return this;
            }

            public TransactionBuilder Amount(double amount)
            {
                if (amount < 0)
                    throw new NegativeMoneyValueException();
                
                _transaction.Amount = amount;

                return this;
            }

            public Transaction Build()
            {
                if (_transaction.AccountToAdd != null) 
                    ThrowIfProhibited(_transaction.AccountToAdd, _transaction.Amount);
                if (_transaction.AccountToDec != null)
                    ThrowIfProhibited(_transaction.AccountToDec, _transaction.Amount);

                return _transaction;
            }

            private void ThrowIfProhibited(IAccount account, double amount)
            {
                if (!account.Owner.IsTrusted() && amount > _maxAmountForNonTrusted)
                {
                    throw new ProhibitedForNonTrustedException();
                }
            }
        }
        
    }
}