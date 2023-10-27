using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoheilShop.Data;
using SoheilShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SoheilShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SoheilShopContext _context;
        public HomeController(ILogger<HomeController> logger, SoheilShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = _context.Products
                .Where(p =>p.Id == id)
                .SelectMany(c=>c.CategoryToProducts)
                .Select(ca=>ca.Category)
                .ToList();
            var VM = new DetailsViewModel()
            {
                product = product,
                categories = categories
            }; 
            
            return View(VM);
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
