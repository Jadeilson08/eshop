using GeekShopping.Frontend.WebApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekShopping.Frontend.WebApp.Pages.Product
{
    public class Delete : PageModel
    {
        private readonly IProductService _service;

        public Delete(IProductService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.Product Product { get; set; }



        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id is null) return NotFound();

            Product = await _service.FindById(id.Value);

            if (Product is null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            bool isDeleted = await _service.Delete(Product.Id);
            
            if (!isDeleted) return BadRequest();

            return RedirectToPage("./Index");
        }
    }
}
