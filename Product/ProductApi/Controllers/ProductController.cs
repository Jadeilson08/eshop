using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.DTO;
using ProductApi.Repository;

namespace ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _repository.FindAll();

                if (products is null) return NoContent();

                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            try
            {
                var product = await _repository.FindById(id);

                if (product is null) return NoContent();

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            if (productDto is null) return BadRequest();

            try
            {
                var product = await _repository.Create(productDto);

                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] long id, [FromBody] ProductDto productDto)
        {
            if ((productDto is null) || id is 0) return BadRequest();

            try
            {
                var product = await _repository.Update(id, productDto);

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            if (id is 0) return BadRequest();

            var result = await _repository.Delete(id);

            if(!result) return BadRequest();
            
            return Ok();
        }
    }
}
