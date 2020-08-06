using ManongTrade.Entity.Interface;

namespace ManongTrade.Entity
{
    public class Product : BaseClass, IProduct
    {
        public string Name { get; set; }
        public short Stock { get; set; }
        public decimal Price { get; set; }
    }
}
