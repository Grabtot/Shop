using Shop.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        private double? _discount;
        private decimal _startPrice;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required, Display(Name = "Price")]
        public decimal StartPrice { get => _startPrice; set => _startPrice = value <= 0 ? throw new ArgumentOutOfRangeException() : value; }

        [Display(Name = "Price with discount ")]
        public decimal DiscountPrice
        {
            get
            {
                var startPrice = decimal.ToDouble(StartPrice);
                var discount = Discount ?? 0;
                return Convert.ToDecimal(startPrice - (startPrice * discount) / 100);
            }
        }
        public double? Discount
        {
            get => _discount; set
            {
                if (_discount <= 0 || _discount > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _discount = value;
            }
        }

        public bool IsDiscounted => Discount is not null;

        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public ProductCategory Category { get; set; }

        public Product()
        {
            Name = string.Empty;
            Manufacturer = string.Empty;
        }

        public Product(ProductViewModel productModel)
        {
            Name = productModel.Name;
            Description = productModel.Description;
            Category = productModel.Category;
            Manufacturer = productModel.Manufacturer;
            StartPrice = productModel.Price;
        }

        public Product(string name, decimal startPrice, ProductCategory category, string manufacturer, string? description)
        {
            Name = name;
            StartPrice = startPrice;
            Category = category;
            Manufacturer = manufacturer;
            Description = description;
        }
    }

    public enum ProductCategory
    {
        PC,
        Laptop,
        Smartphone
    }
}
