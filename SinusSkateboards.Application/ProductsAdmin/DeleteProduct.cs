using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.Application.ProductsAdmin
{
    public class DeleteProduct
    {
        private ApplicationDbContext _dbContext;

        public DeleteProduct(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Do(int id)
        {
            var Product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            _dbContext.Products.Remove(Product);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
