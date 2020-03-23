using System.Collections.Generic;

namespace Lab7
{
    public class Bank
    {
        private List<IAccount> Accounts { get; } = new List<IAccount>();
        public AccountFactory AccountFactory { get; }
        public double MaxAmountForNonTrusted { get; }
        public Bank(double commission, IPercentStrategy percentStrategy,
            double maxAmountForNonTrusted, DateController dateController)
        {
            AccountFactory = new AccountFactory(commission, percentStrategy, 
                account => Accounts.Add(account), dateController);
            MaxAmountForNonTrusted = maxAmountForNonTrusted;
        }

        public Transaction.TransactionBuilder CreateTransactionBuilder()
        {
            return new Transaction.TransactionBuilder(MaxAmountForNonTrusted);
        }

    }
}