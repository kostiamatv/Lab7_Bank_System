namespace Lab7
{
    public class DepositAccount : IAccount, IDateListener
    {
        private double _balance;
        // In days
        public long Id { get; }
        public User Owner { get; }
        public double Amount { get; private set; }
        public double PartPerDay { get; }
        public long DaysLeft { get; private set; }
        
        public DepositAccount(long id, User owner, long term, double startAmount, double partPerPay)
        {
            Id = id;
            Owner = owner;
            DaysLeft = term;
            Amount = startAmount;
            PartPerDay = partPerPay;
        }
        
        public void Add(double amount)
        {
            Amount += amount;
        }

        public void Dec(double amount)
        {
            if (DaysLeft != 0)
            {
                throw new EarlyWithdrawalException();
            }
            if (Amount - amount < 0)
            {
                throw new NegativeMoneyValueException();
            }

            Amount -= amount;
        }
        
        public void Revert(AccountSnapshot snapshot)
        {
            Amount = snapshot.Amount;
        }
        
        public AccountSnapshot CreateSnapshot()
        {
            return new AccountSnapshot(Amount);
        }

        public void OnDayEnd()
        {
            DaysLeft--;
            _balance += Amount * PartPerDay;
        }

        public void OnMonthEnd()
        {
            Amount += _balance;
            _balance = 0;
        }
    }
}