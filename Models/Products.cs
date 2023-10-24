using System.Collections.Generic;

namespace SoheilShop.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }

        public Products()
        {
            Categories = new List<Category>();
        }
    }
}
 