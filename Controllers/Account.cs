using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SoheilShop.Models;
using SoheilShop.Repositories;
using System;

namespace SoheilShop.Controllers
{
    public class Account : Controller
    {
        private IUsersRepository _usersRepository;
        public Account(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
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
            if(_usersRepository.IsExistUserEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "این ایمیل قبلا ثبت نام کرده است");
                return View(register);
            }
            Users users = new Users() 
            {
            Email = register.Email.ToLower(),
            Password = register.Password,
            IsAdmin = false,
            RegisterDate = DateTime.Now
            };
            _usersRepository.AddUser(users);
            return View("SuccessRegister",register);
        }
    }
}
