namespace ManongTrade.Entity.Interface
{
    public interface IOrder : IBase
    {
        int CustomerId { get; set; }
        Customer CustomerObject { get; set; }
        int ProductId { get; set; }
        Product ProductObject { get; set; }
        int ContactId { get; set; }
        Contact ContactObject { get; set; }
        short Status { get; set; }
    }
}
