using Microsoft.Extensions.Configuration;

namespace SoheilShop.Models
{
    public class CategoryToProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }


        public Category Category { get; set; }
        public Product Products { get; set; }
    }
}
