using ProductApi.DTO;
using ProductApi.Models;

namespace ProductApi.Mapping
{
    public static class Extensions
    {
        public static ProductDto MappingToDto(this Product product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            CategoryName = product.CategoryName,
            Description = product.Description,
            ImageURL = product.ImageURL,
            Price = product.Price,
        };
    }
}
