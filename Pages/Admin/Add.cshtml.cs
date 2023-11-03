using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoheilShop.Models;

namespace SoheilShop.Pages.Admin
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddEditProductViewModel  Product { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {

        }
    }
}
