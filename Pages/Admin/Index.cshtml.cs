using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SoheilShop.Data;
using SoheilShop.Models;
using System.Collections;
using System.Collections.Generic;

namespace SoheilShop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private SoheilShopContext _context;
        public IndexModel(SoheilShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Product {  get; set; }
        public void OnGet()
        {
            Product = _context.Products.Include(o => o.Item);
        }
        public void OnPost()
        {   

        }
    }
}
