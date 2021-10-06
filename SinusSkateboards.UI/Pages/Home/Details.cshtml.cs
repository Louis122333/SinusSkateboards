using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;

namespace SinusSkateboards.UI.Pages.Home
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int ColorId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ColorSearch { get; set; }

        public IEnumerable<string> Colors { get; set; }
        public List<Product> Products { get; set; }
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            var categoryType = Product.Category;
            Products = _context.Products.Where(p => p.Category == categoryType).ToList();

            List<string> ListColors = new List<string>();

            foreach (var item in Products)
            {
                ListColors.Add(item.Color);
            }

            var filterList = ListColors.Distinct().ToList();
            filterList.Sort();

            Colors = GetColors(Product, Products, _context);
            if (!String.IsNullOrEmpty(ColorSearch))
            {
                var colorSearchResult = Products.Where(c => c.Color == ColorSearch).ToList();
                if (colorSearchResult != null)
                {
                    Products = colorSearchResult;
                    Product = colorSearchResult.Where(p => p.Color == ColorSearch).FirstOrDefault();
                }
            }

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IEnumerable<string> GetColors(Product product, List<Product> products, ApplicationDbContext context)
        {
            var categoryType = product.Category;
            products = _context.Products.Where(p => p.Category == categoryType).ToList();

            List<string> ListColors = new List<string>();

            foreach (var item in products)
            {
                ListColors.Add(item.Color);
            }

            var filterList = ListColors.Distinct().ToList();
            filterList.Sort();
            return (IEnumerable<string>)filterList;
        }
    }
}
