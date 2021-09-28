using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.Database;
using System.Threading.Tasks;
using SinusSkateboards.Application.CreateProducts;
using SinusSkateboards.Application.GetProducts;
using System.Collections.Generic;

namespace SinusSkateboards.UI.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _dbContext;
    

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Application.CreateProducts.ProductViewModel Product { get; set; }

        public IEnumerable<Application.GetProducts.ProductViewModel> Products { get; set; }
      
       
        public void OnGet()
        {
            Products = new GetProducts(_dbContext).Do();
        }
        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_dbContext).Do(Product);
                return RedirectToPage("Index");
        }
    }
}
