using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using ManongTrade.Entity;

namespace ManongTrade.Data
{
    public class ManongTradeDBContext : DbContext
    {
        public ManongTradeDBContext(DbContextOptions option) : base(option) { }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
