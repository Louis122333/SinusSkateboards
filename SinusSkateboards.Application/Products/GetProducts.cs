using SinusSkateboards.Database;
using System.Collections.Generic;
using System.Linq;

namespace SinusSkateboards.Application.GetProducts
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
                Name = x.Name,
                Description = x.Description,
                Color = x.Color,
                Category = x.Category,
                Price = $"{x.Price:N2} kr",
            });
    }

    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
    }
}

