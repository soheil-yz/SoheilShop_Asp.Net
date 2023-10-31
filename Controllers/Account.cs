using Microsoft.AspNetCore.Mvc;

namespace SoheilShop.Controllers
{
    public class Account : Controller
    {
        public IActionResult Register() 
        {
        return View();
        }
    }
}
