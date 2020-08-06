using System;

namespace ManongTrade.Entity.Interface
{
    public interface IBase
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        int CreatedBy { get; set; }

    }
}
