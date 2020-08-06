using ManongTrade.Entity;

namespace ManongTrade.Repository.Interface
{
    public interface IAdminRepo : IBaseRepo<Admin>
    {
        bool CheckAdmin(short PersonId);
    }
}