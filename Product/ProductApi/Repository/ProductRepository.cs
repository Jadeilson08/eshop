using Microsoft.EntityFrameworkCore;
using ProductApi.ApiException;
using ProductApi.Context;
using ProductApi.DTO;
using ProductApi.Mapping;
using ProductApi.Models;

namespace ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlDbContext _context;

        public ProductRepository(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Create(ProductDto productDto)
        {
            Product product = Product.Create(productDto);

            _context.Add(product);
            await _context.SaveChangesAsync();

            return product.MappingToDto();
        }

        public async Task<bool> Delete(long id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (product is null) return false;
            
            try
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<ProductDto>> FindAll()
        {
            var products = await _context.Product.ToListAsync();
            if (products is null || products.Count == 0)
                throw new NotFoundException();
                
            return products.Select(product => product.MappingToDto());
        }

        public async Task<ProductDto> FindById(long id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (product is null)
                throw new NotFoundException();

            return product.MappingToDto();
        }

        public async Task<ProductDto> Update(long id, ProductDto productDto)
        {
            var product = await _context.Product.FirstOrDefaultAsync(x => x.Id == id);
            
            if (product is null) throw new NotFoundException(Convert.ToString(id));

            product.UpdateFields(productDto);

            _context.Entry(product).State = EntityState.Modified;

            _context.Update(product);
            await _context.SaveChangesAsync();

            return product.MappingToDto();
        }
    }
}
