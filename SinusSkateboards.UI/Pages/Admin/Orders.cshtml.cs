using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;

namespace SinusSkateboards.UI.Pages.Admin
{
    public class OrdersModel : PageModel
    {
        private ApplicationDbContext _context;

        public List<Order> Orders { get; set; }

        public OrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Orders = _context.Orders.OrderByDescending(o => o.Id).ToList();
        }
    }
}
