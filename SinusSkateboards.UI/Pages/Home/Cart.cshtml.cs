using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;
using SinusSkateboards.UI.Helpers;

namespace SinusSkateboards.UI.Pages.Home
{
    public class CartModel : PageModel
    {
        private ApplicationDbContext _context;
        public List<Item> MyCart { get; set; }
        public CartModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            MyCart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        }
        public IActionResult OnGetBuy(int id)
        {
            var product = _context.Products.Find(id);
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item()
                    {
                        Product = product,
                        Quantity = 1
                    });
                }
                else
                {
                    var newQuantity = cart[index].Quantity + 1;
                    cart[index].Quantity = newQuantity;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }
        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

