using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoheilShop.Data;
using System.Linq;

namespace SoheilShop.Controllers
{
    public class ProductController : Controller
    {
        private SoheilShopContext _context;
        public ProductController(SoheilShopContext context)
        {
            _context = context;
        }
        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupName"] = name;
            var produts = _context.CategoryToProducts
                .Where(c=>c.CategoryId == id)
                .Include(c=>c.Products)
                .Select(c=>c.Products)
                .ToList();
            return View(produts);
        }
    }
}
