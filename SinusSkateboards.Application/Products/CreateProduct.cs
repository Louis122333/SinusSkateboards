using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;
using System.Threading.Tasks;

namespace SinusSkateboards.Application.CreateProducts
{
    public class CreateProduct
    {
        private ApplicationDbContext _dbContext;

        public CreateProduct(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Do(ProductViewModel viewModel)
        {
            _dbContext.Products.Add(new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Color = viewModel.Color,
                Category = viewModel.Category,
                Price = viewModel.Price
            });

            await _dbContext.SaveChangesAsync();
        }

    }
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
