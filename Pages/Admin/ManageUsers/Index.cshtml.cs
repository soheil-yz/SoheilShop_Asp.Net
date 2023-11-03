using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SoheilShop.Data;
using SoheilShop.Models;

namespace SoheilShop.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly SoheilShop.Data.SoheilShopContext _context;

        public IndexModel(SoheilShop.Data.SoheilShopContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
