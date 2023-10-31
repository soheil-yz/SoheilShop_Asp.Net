using Microsoft.AspNetCore.Mvc;
using SoheilShop.Data;
using SoheilShop.Models;
using SoheilShop.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace SoheilShop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private IGroupRepository _groupRepository;
        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("/views/Components/ProductGroupsComponent.cshtml", _groupRepository.GetAllShowGroup());
        }
    }
}
