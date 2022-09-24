using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    [Index(nameof(Email), nameof(UserId), IsUnique = true)]
    public class User
    {
        public int Id { get; private set; }
        [Required, StringLength(30)]
        public string Name { get; private set; }
        [Display(Name = "User Id")]
        public Guid UserId { get; private set; }

        [Required, RegularExpression("^.*(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!*+_-]).{8,}$",
            ErrorMessage = "Password must contains at list 1 top and 1 small letters, 1 number and 1 symbol(!,*,+,_ or -)")]
        public string Password { get; private set; }
        [Required, EmailAddress, Display(Prompt = "example@mail.com")]
        public string Email { get; private set; }
        [Phone, RegularExpression(@"^\d.{9}$", ErrorMessage = "Wrong phone format"), Display(Prompt = "0xxxxxxxx")]
        public string? Phone { get; private set; }
        public bool IsAdmin { get; private set; }
        public decimal Balance { get; private set; }
        [Display(Name = "Money Spent")]
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

        public User(UserViewModel userModel) : this()
        {
            Name = userModel.Name;
            Email = userModel.Email;
            Phone = userModel.Phone;
            Password = userModel.Password;
        }

        public User(string name, string password) : this()
        {
            Name = name;
            Password = password;
        }

        public User(string name, string password, string email, string? phone) : this(name, password)
        {
            Email = email;
            Phone = phone;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
