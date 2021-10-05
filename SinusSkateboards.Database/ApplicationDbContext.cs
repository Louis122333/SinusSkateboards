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
        }

    }
}
