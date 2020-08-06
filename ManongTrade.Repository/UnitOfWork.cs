using ManongTrade.Repository.Interface;
using System;

namespace ManongTrade.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManongTradeContext _context;

        public UnitOfWork(ManongTradeContext context)
        {
            _context = context;
            AdminRepo = new AdminRepo(_context);
            CustomerRepo = new CustomerRepo(_context);
            ProductRepo = new ProductRepo(_context);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public IAdminRepo AdminRepo { get; private set; }
        public ICustomerRepo CustomerRepo { get; private set; }
        public IProductRepo ProductRepo { get; private set; }
    }
}
