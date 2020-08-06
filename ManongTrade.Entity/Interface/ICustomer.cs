namespace ManongTrade.Entity.Interface
{
    public interface ICustomer : IBase
    {
        string Username { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
    }
}
