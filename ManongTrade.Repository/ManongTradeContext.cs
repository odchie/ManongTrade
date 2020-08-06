using ManongTrade.Entity;
using Microsoft.EntityFrameworkCore;

namespace ManongTrade.Repository
{
    public class ManongTradeContext : DbContext
    {
        public ManongTradeContext(DbContextOptions option) : base(option) { }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Customer> Person { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
