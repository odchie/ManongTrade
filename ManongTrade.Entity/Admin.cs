using ManongTrade.Entity.Interface;

namespace ManongTrade.Entity
{
    public class Admin : BaseClass, IAdmin
    {
        public int PersonId { get; set; }
    }
}
