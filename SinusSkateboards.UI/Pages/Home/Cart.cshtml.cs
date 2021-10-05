using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;
using SinusSkateboards.UI.Helpers;

namespace SinusSkateboards.UI.Pages.Cart
{
    public class CartModel : PageModel
    {
        private ApplicationDbContext _context;
        public List<CartProduct> MyCart { get; set; }
        public CartModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            MyCart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
        }

        //public void OnGetDelete(int id)
        //{
        //    MyCart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
        //    int index = Exists(MyCart, id);
        //    MyCart.RemoveAt(index);
        //    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", MyCart);
            
        //}

        public IActionResult OnGetBuy(int id)
        {
            var product = _context.Products.Find(id);
             MyCart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            if (MyCart == null)
            {
                MyCart = new List<CartProduct>();
                MyCart.Add(new CartProduct()
                {
                    Product = product,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", MyCart);
            }
            else
            {
                var index = Exists(MyCart, id);
                if (index == -1)
                {
                    MyCart.Add(new CartProduct()
                    {
                        Product = product,
                        Quantity = 1
                    });
                }
                else
                {
                    var newQuantity = MyCart[index].Quantity + 1;
                    MyCart[index].Quantity = newQuantity;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", MyCart);
            }
            return RedirectToPage("Cart");
        }
        private int Exists(List<CartProduct> MyCart, int id)
        {
            for (int i = 0; i < MyCart.Count; i++)
            {
                if (MyCart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

