using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SoheilShop.Models;

namespace SoheilShop.Controllers
{
    public class Account : Controller
    {
        public IActionResult Register() 
        {
        return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            return View();
        }
    }
}
