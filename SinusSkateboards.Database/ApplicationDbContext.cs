using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinusSkateboards.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Order>()
                .HasOne(a => a.Cart)
                .WithOne(b => b.Order)
                .HasForeignKey<Cart>(c => c.OrderId);
            builder.Entity<Cart>()
                .HasMany(a => a.CartProduct)
                .WithOne(b => b.Cart)
                .HasForeignKey(c => c.CartId);
            builder.Entity<Order>()
          .HasOne(a => a.Customer)
          .WithOne(b => b.Order)
          .HasForeignKey<Customer>(c => c.OrderId);
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Sinus Hoodie",
                    Description = "Spared no expense",
                    Color = "Blue",
                    Category = "Hoodies",
                    Price = 399,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\hoodie-ocean.png",
                    PhotoName = "hoodie-ocean.png"
                },
                new Product
                {
                    Id = 2,
                    Name = "Sinus Hoodie",
                    Description = "Spared no expense",
                    Color = "Carbon",
                    Category = "Hoodies",
                    Price = 399,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\hoodie-ash.png",
                    PhotoName = "hoodie-ash.png"
                },
                new Product
                {
                    Id = 3,
                    Name = "Sinus Hoodie",
                    Description = "Spared no expense",
                    Color = "Purple",
                    Category = "Hoodies",
                    Price = 399,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\hoodie-purple.png",
                    PhotoName = "hoodie-purple.png"
                },
                new Product
                {
                    Id = 4,
                    Name = "Sinus Hoodie",
                    Description = "Spared no expense",
                    Color = "Green",
                    Category = "Hoodies",
                    Price = 399,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\hoodie-green.png",
                    PhotoName = "hoodie-green.png"
                },
                new Product
                {
                    Id = 5,
                    Name = "Sinus Hoodie",
                    Description = "Spared no expense",
                    Color = "Red",
                    Category = "Hoodies",
                    Price = 399,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\hoodie-fire.png",
                    PhotoName = "hoodie-fire.png"
                },
                new Product
                {
                    Id = 6,
                    Name = "Sinus Cap",
                    Description = "Very cool cap",
                    Color = "Blue",
                    Category = "Caps",
                    Price = 179,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-cap-blue.png",
                    PhotoName = "sinus-cap-blue.png"
                },
                new Product
                {
                    Id = 7,
                    Name = "Sinus Cap",
                    Description = "Very cool cap",
                    Color = "Green",
                    Category = "Caps",
                    Price = 179,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-cap-green.png",
                    PhotoName = "sinus-cap-green.png"
                },
                new Product
                {
                    Id = 8,
                    Name = "Sinus Cap",
                    Description = "Very cool cap",
                    Color = "Purple",
                    Category = "Caps",
                    Price = 179,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-cap-purple.png",
                    PhotoName = "sinus-cap-purple.png"
                },
                new Product
                {
                    Id = 9,
                    Name = "Sinus Cap",
                    Description = "Very cool cap",
                    Color = "Red",
                    Category = "Caps",
                    Price = 179,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-cap-red.png",
                    PhotoName = "sinus-cap-red.png"
                },
                new Product
                {
                    Id = 10,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Eagle",
                    Category = "Skateboards",
                    Price = 599,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-eagle.png",
                    PhotoName = "sinus-skateboard-eagle.png"
                },
                new Product
                {
                    Id = 11,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Fire",
                    Category = "Skateboards",
                    Price = 899,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-fire.png",
                    PhotoName = "sinus-skateboard-fire.png"
                },
                new Product
                {
                    Id = 12,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Greta",
                    Category = "Skateboards",
                    Price = 1599,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-gretasfury.png",
                    PhotoName = "sinus-skateboard-gretasfury.png"
                },
                new Product
                {
                    Id = 13,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Ink",
                    Category = "Skateboards",
                    Price = 750,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-ink.png",
                    PhotoName = "sinus-skateboard-ink.png"
                },
                new Product
                {
                    Id = 14,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Wood",
                    Category = "Skateboards",
                    Price = 450,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-logo.png",
                    PhotoName = "sinus-skateboard-logo.png"
                },
                new Product
                {
                    Id = 15,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Aurora",
                    Category = "Skateboards",
                    Price = 1100,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-northern_lights.png",
                    PhotoName = "sinus-skateboard-northern_lights.png"
                },
                new Product
                {
                    Id = 16,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Multicolor",
                    Category = "Skateboards",
                    Price = 650,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-plastic.png",
                    PhotoName = "sinus-skateboard-plastic.png"
                },
                new Product
                {
                    Id = 17,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Carbon",
                    Category = "Skateboards",
                    Price = 799,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-polar.png",
                    PhotoName = "sinus-skateboard-polar.png"
                },
                new Product
                {
                    Id = 18,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Purple",
                    Category = "Skateboards",
                    Price = 800,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-purple.png",
                    PhotoName = "sinus-skateboard-purple.png"
                },
                new Product
                {
                    Id = 19,
                    Name = "Sinus Board",
                    Description = "Built for longer grinds",
                    Color = "Yellow",
                    Category = "Skateboards",
                    Price = 500,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-skateboard-yellow.png",
                    PhotoName = "sinus-skateboard-yellow.png"
                },
                new Product
                {
                    Id = 20,
                    Name = "Sinus T-Shirt",
                    Description = "Handmade",
                    Color = "Blue",
                    Category = "T-Shirts",
                    Price = 240,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-tshirt-blue.png",
                    PhotoName = "sinus-tshirt-blue.png"
                },
                new Product
                {
                    Id = 21,
                    Name = "Sinus T-Shirt",
                    Description = "Handmade",
                    Color = "Carbon",
                    Category = "T-Shirts",
                    Price = 240,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-tshirt-grey.png",
                    PhotoName = "sinus-tshirt-grey.png"
                },
                new Product
                {
                    Id = 22,
                    Name = "Sinus T-Shirt",
                    Description = "Handmade",
                    Color = "Pink",
                    Category = "T-Shirts",
                    Price = 240,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-tshirt-pink.png",
                    PhotoName = "sinus-tshirt-pink.png"
                },
                new Product
                {
                    Id = 23,
                    Name = "Sinus T-Shirt",
                    Description = "Handmade",
                    Color = "Purple",
                    Category = "T-Shirts",
                    Price = 240,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-tshirt-purple.png",
                    PhotoName = "sinus-tshirt-purple.png"
                },
                new Product
                {
                    Id = 24,
                    Name = "Sinus T-Shirt",
                    Description = "Handmade",
                    Color = "Yellow",
                    Category = "T-Shirts",
                    Price = 240,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-tshirt-yellow.png",
                    PhotoName = "sinus-tshirt-yellow.png"
                },
                new Product
                {
                    Id = 25,
                    Name = "Sinus Wheel 4p",
                    Description = "Fluid roll",
                    Color = "Red",
                    Category = "Wheels",
                    Price = 350,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-wheel-rocket.png",
                    PhotoName = "sinus-wheel-rocket.png"
                },
                new Product
                {
                    Id = 26,
                    Name = "Sinus Wheel 4p",
                    Description = "Fluid roll",
                    Color = "White",
                    Category = "Wheels",
                    Price = 350,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-wheel-spinner.png",
                    PhotoName = "sinus-wheel-spinner.png"
                },
                new Product
                {
                    Id = 27,
                    Name = "Sinus Wheel 4p",
                    Description = "Fluid roll",
                    Color = "Carbon",
                    Category = "Wheels",
                    Price = 350,
                    PhotoPath = @"~\SinusSkateboards\SinusSkateboards.UI\wwwroot\images\sinus-wheel-wave.png",
                    PhotoName = "sinus-wheel-wave.png"
                });
        }

    }
}
