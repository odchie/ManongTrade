using ManongTrade.UI.Shop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManongTrade.UI.Shop.Models
{
    public class ApiResponseModel<TEntity> where TEntity : class
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public TEntity ReturnObject { get; set; }
    }
}
