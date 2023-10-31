using SoheilShop.Data;
using SoheilShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace SoheilShop.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();    ///probably is wrong
        IEnumerable<ShowGroupViewModel> GetAllShowGroup();
    }

    public class GroupRepository : IGroupRepository
    {
        private SoheilShopContext _context;
        public GroupRepository(SoheilShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Category;
        }

        public IEnumerable<ShowGroupViewModel> GetAllShowGroup()
        {
           return _context.Category.Select(c => new ShowGroupViewModel()
            {
                GroupId = c.Id,
                Name = c.Name,
                ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
            }).ToList();
        }
    }
}
