using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Frontend.WebApp.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } = string.Empty;

        [Display(Name = "Image URL")]
        public string ImageURL { get; set; } = string.Empty;
    }
}
