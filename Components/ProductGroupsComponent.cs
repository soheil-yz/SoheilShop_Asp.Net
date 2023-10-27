using Microsoft.AspNetCore.Mvc;
using SoheilShop.Data;
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
            return View("/views/Components/ProductGroupsComponent.cshtml",_context.Category);
        }



    }
}
