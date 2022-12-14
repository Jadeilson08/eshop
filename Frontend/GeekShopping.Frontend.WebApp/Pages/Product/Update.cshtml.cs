using GeekShopping.Frontend.WebApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekShopping.Frontend.WebApp.Pages.Product
{
    public class Update : PageModel
    {
        private readonly IProductService _service;

        [BindProperty]
        public Models.Product Product { get; set; }

        public Update(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id is null) return NotFound();

            Product = await _service.FindById(id.Value);

            if (Product is null) return NotFound();


            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var product = await _service.Update(Product.Id, Product);

            return RedirectToPage("./Index");
        }
    }
}
