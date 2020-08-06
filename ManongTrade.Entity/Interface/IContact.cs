namespace ManongTrade.Entity.Interface
{
    public interface IContact : IBase
    {
        int CustomerId { get; set; }
        Customer CustomerObject { get; set; }
        string Phone { get; set; }
        string Address { get; set; }

    }
}
