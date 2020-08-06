using ManongTrade.Entity.Interface;
using System;

namespace ManongTrade.Entity
{
    public abstract class BaseClass : IBase
    {
        public virtual int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
