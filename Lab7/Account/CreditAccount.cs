namespace Lab7
{
    public class CreditAccount : IAccount
    {
        public long Id { get; }
        public User Owner { get; }
        public double Amount { get; private set; }
        public double CreditLimit { get; }
        public double Commission { get; }

        public CreditAccount(long id, User owner, double creditLimit, double commission)
        {
            Id = id;
            Owner = owner;
            CreditLimit = creditLimit;
            Commission = commission;
        }
        
        public void Add(double amount)
        {
            Amount += amount;
        }

        public void Dec(double amount)
        {
            if (Amount > -CreditLimit)
            {
                Amount -= amount;
            }
            else
            {
                Amount -= (amount + amount * Commission);
            }
        }

        public void Revert(AccountSnapshot snapshot)
        {
            Amount = snapshot.Amount;
        }

        public AccountSnapshot CreateSnapshot()
        {
            return new AccountSnapshot(Amount);
        }
    }
}