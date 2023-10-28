using Microsoft.AspNetCore.Mvc;
using SoheilShop.Data;
using SoheilShop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SoheilShop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private SoheilShopContext _context;

        public ProductGroupsComponent(SoheilShopContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _context.Category.Select(c => new ShowGroupViewModel()
            {
                GroupId = c.Id,
                Name = c.Name,
                ProductCount = _context.CategoryToProducts.Count(g=>g.CategoryId == c.Id)
            }).ToList();
            return View("/views/Components/ProductGroupsComponent.cshtml", categories);
        }
    }
}
