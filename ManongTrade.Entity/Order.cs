using ManongTrade.Entity.Interface;

namespace ManongTrade.Entity
{
    public class Order : BaseClass, IOrder
    {
        public int CustomerId { get; set; }
        public Customer CustomerObject { get; set; }
        public int ProductId { get; set; }
        public Product ProductObject { get; set; }
        public int ContactId { get; set; }
        public Contact ContactObject { get; set; }
        public short Status { get; set; }
    }
}
