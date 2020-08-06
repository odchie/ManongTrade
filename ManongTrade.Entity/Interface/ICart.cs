namespace ManongTrade.Entity.Interface
{
    public interface ICart : IBase
    {
        int CustomerId { get; set; }
        int ProdutId { get; set; }
    }
}
