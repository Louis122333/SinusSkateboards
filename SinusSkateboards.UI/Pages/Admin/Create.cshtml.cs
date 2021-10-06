using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SinusSkateboards.Database;
using SinusSkateboards.Domain.Models;

namespace SinusSkateboards.UI.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment _web;
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment web)
        {
            _web = web;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile uploadFiles, Product product)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string imgText = Path.GetExtension(uploadFiles.FileName);
            if (imgText == ".jpg" || imgText == ".png")
            {
                var imgSave = Path.Combine(_web.WebRootPath, "images", uploadFiles.FileName);
                var stream = new FileStream(imgSave, FileMode.Create);
                await uploadFiles.CopyToAsync(stream);
                stream.Close();

                product.PhotoName = uploadFiles.FileName;
                product.PhotoPath = imgSave;
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
