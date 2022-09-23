namespace Shop.Models
{
    public class History
    {
        public int Id { get; private set; }
        public User User { get; private set; }
        public Product Product { get; private set; }
        public decimal Price { get; private set; }
    }
}
