using Shop.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class ProductViewModel
    {
        [Required, StringLength(40)]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public ProductCategory Category { get; set; }
    }
}
