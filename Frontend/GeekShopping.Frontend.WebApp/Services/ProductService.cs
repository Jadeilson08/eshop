using GeekShopping.Frontend.WebApp.Extensios;
using GeekShopping.Frontend.WebApp.Models;
using GeekShopping.Frontend.WebApp.Services.Interface;

namespace GeekShopping.Frontend.WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string BasePath = "api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<Product> Create(Product product)
        {
            var response = await _httpClient.PostAsJson(BasePath, product);

            if(response.IsSuccessStatusCode)
                return await response.ReadContentAs<Product>();

            throw new Exception("Something is wrong when callling API");
        }

        public async Task<bool> Delete(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            
            if (response.IsSuccessStatusCode)
                return true;

            throw new Exception("Something is wrong when callling API");
        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            var response = await _httpClient.GetAsync(BasePath);

            return await response.ReadContentAs<List<Product>>();
        }

        public async Task<Product> FindById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");

            return await response.ReadContentAs<Product>();
        }

        public async Task<Product> Update(long id, Product product)
        {
            var response = await _httpClient.PutAsJson($"{BasePath}/{id}", product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Product>();

            throw new Exception("Something is wrong when callling API");
        }
    }
}
