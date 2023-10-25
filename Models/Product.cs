﻿using System.Collections.Generic;

namespace SoheilShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ItemId { get; set; }
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }

        public Item Item { get; set; }
    }
}
 