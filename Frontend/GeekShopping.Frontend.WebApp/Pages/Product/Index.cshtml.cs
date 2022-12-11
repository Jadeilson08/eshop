using GeekShopping.Frontend.WebApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace GeekShopping.Frontend.WebApp.Pages.Product
{
    public class Index : PageModel
    {
        private readonly IProductService _service;

        public IEnumerable<Models.Product> products { get; set; } = default!;

        public Index(IProductService service)
        {
            _service = service;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            products = await _service.FindAll();
            return Page();
        }
    }
}
