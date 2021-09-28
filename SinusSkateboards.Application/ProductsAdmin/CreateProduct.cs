using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;
using System.Threading.Tasks;

namespace SinusSkateboards.Application.ProductsAdmin
{
    public class CreateProduct
    {
        private ApplicationDbContext _dbContext;

        public CreateProduct(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response> Do(Request request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Color = request.Color,
                Category = request.Category,
                Price = request.Price
            };

            _dbContext.Products.Add(product);

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
