using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.Database;
using System.Threading.Tasks;
using SinusSkateboards.Application.Products;
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

        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
      
       
        public void OnGet()
        {
            Products = new GetProducts(_dbContext).Do();
        }
       
    }
}
