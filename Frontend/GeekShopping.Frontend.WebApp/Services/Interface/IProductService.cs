using GeekShopping.Frontend.WebApp.Models;

namespace GeekShopping.Frontend.WebApp.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> FindAll();
        Task<Product> FindById(long id);
        Task<Product> Create(Product product);
        Task<Product> Update(long id, Product product);
        Task<bool> Delete(long id);
    }
}
