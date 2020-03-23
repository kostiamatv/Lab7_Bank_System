using System;

namespace Lab7
{
    public class AccountFactory
    {
        private long _id;
        private readonly double _commission;
        private readonly IPercentStrategy _percentStrategy;
        private readonly Action<IAccount> _accountCreated;
        private readonly DateController _dateController;

        public AccountFactory(double commission, IPercentStrategy percentStrategy,
            Action<IAccount> accountCreated, DateController dateController)
        {
            _commission = commission;
            _percentStrategy = percentStrategy;
            _accountCreated = accountCreated;
            _dateController = dateController;
        }

        public IAccount CreateDepositAccount(User owner, long term, double startAmount)
        {
            var account = new DepositAccount(_id++, owner, term, 
                startAmount, PartPerDay(_percentStrategy.CalculatePercent(startAmount)));
            _accountCreated.Invoke(account);
            _dateController.AddDateListener(account);
            return account;
        }

        public IAccount CreateDebitAccount(User owner, double percentPerYear)
        {
            var account = new DebitAccount(_id++, owner, PartPerDay(percentPerYear));
            _accountCreated.Invoke(account);
            _dateController.AddDateListener(account);
            return account;
        }

        public IAccount CreateCreditAccount(User owner, double creditLimit)
        {
            var account = new CreditAccount(_id++, owner, creditLimit, _commission);
            _accountCreated.Invoke(account);
            return account;
        }

        private static double PartPerDay(double percentPerYear)
        {
            return percentPerYear / 365 / 100;
        }
    }
}