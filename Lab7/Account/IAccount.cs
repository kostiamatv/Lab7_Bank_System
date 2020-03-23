namespace Lab7
{
    public interface IAccount
    {
        long Id { get; }
        User Owner { get; }
        double Amount { get; }
        void Add(double amount);
        void Dec(double amount);
        void Revert(AccountSnapshot snapshot);
        AccountSnapshot CreateSnapshot();
    }
}