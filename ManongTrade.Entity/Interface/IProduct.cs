namespace ManongTrade.Entity.Interface
{
    public interface IProduct : IBase
    {
        string Name { get; set; }
        short Stock { get; set; }
        decimal Price { get; set; }

    }
}
