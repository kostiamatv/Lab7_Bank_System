namespace Lab7
{
    public class DefaultPercentStrategy : IPercentStrategy
    {
        public double CalculatePercent(double startAmount)
        {
            if (startAmount < 50000)
            {
                return 5;
            } else if (startAmount < 100000)
            {
                return 6;
            }
            else
            {
                return 7;
            }
        }
    }
}