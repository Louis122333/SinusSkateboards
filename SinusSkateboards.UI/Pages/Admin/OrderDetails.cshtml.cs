using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;

namespace SinusSkateboards.UI.Pages.Admin
{
    public class OrderDetailsModel : PageModel
    {
        private ApplicationDbContext _context;

        public Order Order { get; set; }
        public OrderDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Order = await _context.Orders.Include(c => c.Customer).Include(ca => ca.Cart.CartProduct).ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
           
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
