using ProductApi.DTO;

namespace ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> FindAll();
        Task<ProductDto> FindById(long id);
        Task<ProductDto> Create(ProductDto product);
        Task<ProductDto> Update(long id, ProductDto product);
        Task<bool> Delete(long id);
    }
}
