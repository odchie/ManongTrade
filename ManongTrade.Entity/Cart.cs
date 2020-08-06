using ManongTrade.Entity.Interface;

namespace ManongTrade.Entity
{
    public class Cart : BaseClass, ICart
    {
        public int CustomerId { get; set; }
        public int ProdutId { get; set; }
    }
}