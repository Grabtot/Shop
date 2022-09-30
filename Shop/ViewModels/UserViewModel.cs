using Microsoft.AspNetCore.Identity;
using Shop.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class UserViewModel
    {

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required, RegularExpression("^.*(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!*+_-]).{8,}$",
          ErrorMessage = "Password must contains at list 1 top and 1 small letters, 1 number and 1 symbol(!,*,+,_ or -)")]
        public string Password { get; set; }

        [Required, Compare(nameof(Password), ErrorMessage = "Passwords must be the same")]
        public string ConfirmPassword { get; set; }

        [Required, EmailAddress, Display(Prompt = "example@mail.com")]
        public string Email { get; set; }
        [Phone, RegularExpression(@"^\d.{9}$", ErrorMessage = "Wrong phone format"), Display(Prompt = "0xxxxxxxx")]
        public string? Phone { get; set; }
    }
}
