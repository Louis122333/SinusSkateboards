using SinusSkateboards.Database;
using System.Collections.Generic;
using System.Linq;

namespace SinusSkateboards.Application.ProductsAdmin
{
    public class GetProduct
    {
        private ApplicationDbContext _dbContext;

        public GetProduct(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductViewModel Do(int id) => 
            _dbContext.Products.Where(x => x.Id == id).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Color = x.Color,
                Category = x.Category,
                Price = x.Price
            })
            .FirstOrDefault();

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Color { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
        }
    }

  
}

