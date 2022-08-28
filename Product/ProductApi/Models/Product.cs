using ProductApi.DTO;

namespace ProductApi.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {

        }
        private Product(ProductDto productDto)
        {
            Name = productDto.Name ?? throw new ArgumentNullException(nameof(productDto.Name));
            Price = productDto.Price ?? throw new ArgumentNullException(nameof(productDto.Price));
            Description = productDto.Description;
            CategoryName = productDto.CategoryName;
            ImageURL = productDto.ImageURL;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public string Description { get; private set; }

        public string CategoryName { get; private set; }

        public string ImageURL { get; private set; }

        internal void UpdateFields(ProductDto productDto)
        {
            if (!string.IsNullOrWhiteSpace(productDto.Name)) Name = productDto.Name;
            if (!productDto.Price.Equals(null)) Price = (decimal)productDto.Price;
            if (!string.IsNullOrWhiteSpace(productDto.Description)) Description = productDto.Description;
            if (!string.IsNullOrWhiteSpace(productDto.CategoryName)) CategoryName = productDto.CategoryName;
            if (!string.IsNullOrWhiteSpace(productDto.ImageURL)) ImageURL = productDto.ImageURL;
        }

        public static Product Create(ProductDto productDto) => new Product(productDto);
     
    }
}
