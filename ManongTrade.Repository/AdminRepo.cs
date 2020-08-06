using ManongTrade.Entity;
using ManongTrade.Repository.Interface;

namespace ManongTrade.Repository
{
    public class AdminRepo : BaseRepo<Admin>, IAdminRepo
    {
        public AdminRepo(ManongTradeContext context) : base(context) { }
        public bool CheckAdmin(short PersonId)
        {
            return base.SingleOrDefault(x => x.PersonId == PersonId) != null;
        }
    }
}
