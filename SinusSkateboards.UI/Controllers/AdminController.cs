using Microsoft.AspNetCore.Mvc;
using SinusSkateboards.Application.ProductsAdmin;
using SinusSkateboards.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct.Request request) => Ok(await new CreateProduct(_dbContext).Do(request));

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id) => Ok(await new DeleteProduct(_dbContext).Do(id));

        [HttpGet("products/{id}")]
        public IActionResult GetProduct(int id) => Ok(new GetProduct(_dbContext).Do(id));

        [HttpGet("products")]
        public IActionResult GetProducts() => Ok(new GetProducts(_dbContext).Do());

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct.Request request) => Ok(await new UpdateProduct(_dbContext).Do(request));
 

    }
}
