using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.Domain.Models;
using SinusSkateboards.UI.Helpers;

namespace SinusSkateboards.UI.Pages.Home
{
    public class ConfirmationModel : PageModel
    {
        public List<CartProduct> MyCart { get; set; }
        public void OnGet()
        {
            MyCart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
        }
    }
}
