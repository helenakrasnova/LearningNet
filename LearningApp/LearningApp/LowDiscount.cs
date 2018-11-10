namespace LearningApp
{
    class LowDiscount : IDiscount
    {
        public decimal GetDiscount()
        {
            return 5;
        }
    }
}
