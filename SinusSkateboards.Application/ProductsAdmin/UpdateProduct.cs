using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.Application.ProductsAdmin
{
    public class UpdateProduct
    {
        private ApplicationDbContext _dbContext;

        public UpdateProduct(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response> Do(Request request)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == request.Id);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Color = request.Color;
            product.Category = request.Category;
            product.Price = request.Price;

            await _dbContext.SaveChangesAsync();
            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Color = product.Color,
                Category = product.Category,
                Price = product.Price
            };
        }
            
        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Color { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
        }

        public class Response
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
