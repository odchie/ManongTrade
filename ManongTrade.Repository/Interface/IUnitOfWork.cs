namespace ManongTrade.Repository.Interface
{
    public interface IUnitOfWork
    {
        IAdminRepo AdminRepo { get; }
        ICustomerRepo CustomerRepo { get; }
        IProductRepo ProductRepo { get; }
        int SaveChanges();
    }
}