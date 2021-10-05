using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;
using SinusSkateboards.UI.Helpers;

namespace SinusSkateboards.UI.Pages.Home
{
    public class CheckoutModel : PageModel
    {
        private ApplicationDbContext _context;

        [BindProperty]
        public Customer Customer { get; set; }
        
        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public Domain.Models.Cart Cart { get; set; }

        public List<CartProduct> MyCart { get; set; }
        public decimal Total { get; set; }
        public CheckoutModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            MyCart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            Total = MyCart.Sum(item => item.Product.Price * item.Quantity);
        }
        public IActionResult OnPost()
        {
            List<CartProduct> cartProducts = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");

            decimal totalPrice = 0m;
            Domain.Models.Cart cart = new Domain.Models.Cart();
            cart.CartProduct = new List<CartProduct>();

            foreach (var cartProduct in cartProducts)
            {
                cart.CartProduct.Add(cartProduct);
                totalPrice += cartProduct.Product.Price * cartProduct.Quantity;
                
            }

            Order order = new Order()
            {
                Cart = cart,
                Customer = new Customer()
                {
                    FirstName = Customer.FirstName,
                    LastName = Customer.LastName,
                    Address = Customer.Address,
                    PhoneNumber = Customer.PhoneNumber,
                    City = Customer.City,
                    PostalCode = Customer.PostalCode,
                },
                OrderDate = DateTime.Now,
                Price = totalPrice
            };
            _context.Orders.Add(order);

            _context.Database.OpenConnection();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products ON;");
            _context.SaveChanges();
           
            return RedirectToPage("Index");
        }
    }
}

