namespace SoheilShop.Models
{
    public class Item
    {
        public int Id { get; set; }

        public Products Products { get; set; }
        public string Price { get; set; }
        public int QuantityInStock {  get; set; }

    }
}
