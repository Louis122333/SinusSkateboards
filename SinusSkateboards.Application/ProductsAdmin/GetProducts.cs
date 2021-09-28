using SinusSkateboards.Database;
using System.Collections.Generic;
using System.Linq;

namespace SinusSkateboards.Application.ProductsAdmin
{
    public class GetProducts
    {
        private ApplicationDbContext _dbContext;

        public GetProducts(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductViewModel> Do() => 
            _dbContext.Products.ToList().Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Color = x.Color,
                Category = x.Category,
                Price = x.Price
            });

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Color { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
        }
    }

  
}

