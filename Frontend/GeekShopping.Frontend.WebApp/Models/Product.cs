using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Frontend.WebApp.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        
        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }
    }
}
