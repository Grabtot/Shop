namespace Shop.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Guid UserId { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public decimal Balance { get; private set; }
        public decimal MoneySpent { get; private set; }
        public List<Product> Cart { get; private set; }
        public List<History> History { get; private set; }

        private User()
        {
            Balance = 100;
            MoneySpent = 0;
            UserId = Guid.NewGuid();
            Cart = new List<Product>();
            History = new List<History>();

            Name = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Password = string.Empty;
        }



    }
}
