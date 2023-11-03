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
    public class DetailsModel : PageModel
    {
        private readonly SoheilShop.Data.SoheilShopContext _context;

        public DetailsModel(SoheilShop.Data.SoheilShopContext context)
        {
            _context = context;
        }

        public Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
