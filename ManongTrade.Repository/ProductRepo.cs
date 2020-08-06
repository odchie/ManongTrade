using ManongTrade.Entity;
using ManongTrade.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManongTrade.Repository
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(ManongTradeContext context) : base(context) { }
    }
}
