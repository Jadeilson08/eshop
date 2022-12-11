using GeekShopping.Frontend.WebApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekShopping.Frontend.WebApp.Pages.Product
{
    public class Create : PageModel
    {
        private readonly IProductService _service;

        public Create(IProductService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public Models.Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var product = await _service.Create(Product);

            return RedirectToPage("./Index");
        }
    }
}
