using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private static Cart _cart=new Cart();   
        public HomeController(ILogger<HomeController> logger, SoheilShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products
                .ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(c=>c.Id == id);

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
        public IActionResult AddToCart(int itemId) 
        {
            var product = _context.Products.Include(p=>p.Item).SingleOrDefault(p => p.ItemId == itemId);
            if (product != null)
            {
                var cartItem = new CartItem()
                {
                    Item = product.Item,
                    Quantity = 1,

                };
                _cart.addCartItem(cartItem);
            }
            return null;
        }
        public IActionResult ShowCart()
        {
            return View();
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
