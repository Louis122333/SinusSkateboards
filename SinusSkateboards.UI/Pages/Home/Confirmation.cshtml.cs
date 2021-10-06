using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;
using SinusSkateboards.UI.Helpers;

namespace SinusSkateboards.UI.Pages.Home
{
    public class ConfirmationModel : PageModel
    {
        private ApplicationDbContext _context;

        public ConfirmationModel(ApplicationDbContext context)
        {
            _context = context;
        }
   
        public List<CartProduct> MyCart { get; set; }
        public Order Order { get; set; }

        public void OnGet(int order)
        {
            MyCart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            Order = _context.Orders.Where(o => o.Id == order).FirstOrDefault();
            RemoveCookie("cart");
        }

        public void RemoveCookie(string key)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(-1);
            option.Secure = true;
            option.IsEssential = true;
            Response.Cookies.Append(key, string.Empty, option);
            Response.Cookies.Delete(key);
        }
    }
}
