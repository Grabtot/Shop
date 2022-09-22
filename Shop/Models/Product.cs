namespace Shop.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal StartPryce { get; private set; }
        public decimal FinalPryce => (decimal)(decimal.ToDouble(StartPryce) - (decimal.ToDouble(StartPryce) * (Discount.Value)) / 100);
        public double? Discount { get; private set; }
        public string Manufacturer { get; private set; }

        private Product() { }
    }
}
