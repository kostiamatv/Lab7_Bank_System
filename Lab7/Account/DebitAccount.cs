namespace Lab7
{
    public class DebitAccount : IAccount, IDateListener
    {
        private double _balance;
        public long Id { get; }
        public User Owner { get; }
        public double PartPerDay { get; }
        public double Amount { get; private set; }

        public DebitAccount(long id, User owner, double partPerPay)
        {
            Id = id;
            Owner = owner;
            PartPerDay = partPerPay;
        }
        
        public void Add(double amount)
        {
            Amount += amount;
        }

        public void Dec(double amount)
        {
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
            _balance += Amount * PartPerDay;
        }

        public void OnMonthEnd()
        {
            Amount += _balance;
            _balance = 0;
        }
    }
}