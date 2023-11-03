using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SoheilShop.Data;
using SoheilShop.Models;
using System.IO;

namespace SoheilShop.Pages.Admin
{
    public class AddModel : PageModel
    {
        private SoheilShopContext _context;
        public AddModel(SoheilShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel  Product { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
                return Page();
            var item = new Item()
            {
                Price = Product.Price,
                QuantityInStock = Product.QuantityInStock,
            };
            _context.Add(item);
            _context.SaveChanges();

            var pro = new Product()
            {
                Name = Product.Name,
                Item = item,
                Description = Product.Description,
            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.ItemId = pro.Id;
            _context.SaveChanges();

            if(Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", pro.Id + Path.GetExtension(Product.Picture.FileName));

                using (var stream = new FileStream(filePath , FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("Index");
        }
    }
}
