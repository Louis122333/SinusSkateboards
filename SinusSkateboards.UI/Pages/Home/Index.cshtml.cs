using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;

namespace SinusSkateboards.UI.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Product> Product { get; set; }
        public SelectList Category { get; set; }

        public async Task OnGetAsync(string searchString, string category)
        {
            Product = await _context.Products.ToListAsync();

            var products = from p in _context.Products
                           select p;

            IQueryable<string> categoryQuery = from c in _context.Products
                           orderby c.Category
                           select c.Category;

            if (!String.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString) || p.Color.Contains(searchString)
                || p.Category.Contains(searchString));
            }
            Category = new SelectList(await categoryQuery.Distinct().ToListAsync());
            Product = await products.ToListAsync();
        }
    }
}
