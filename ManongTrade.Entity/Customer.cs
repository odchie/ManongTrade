using System.ComponentModel.DataAnnotations.Schema;
using ManongTrade.Entity.Interface;

namespace ManongTrade.Entity
{
    public class Customer : BaseClass, ICustomer
    {
        [NotMapped]
        public virtual string Token { get; set; }
        public virtual string Username { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
    }
}
