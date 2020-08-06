using ManongTrade.Entity.Interface;
using System;

namespace ManongTrade.Entity
{
    public class Contact : BaseClass, IContact
    {
        public int CustomerId { get; set; }
        public Customer CustomerObject { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
