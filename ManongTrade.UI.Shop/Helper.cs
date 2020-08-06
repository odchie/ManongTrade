using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManongTrade.UI.Shop.Helper
{
    public enum ApiResponse
    {
        Ok,
        NotOk
    }
    public enum OrderStatus
    {
        Ordered,
        Shipped,
        Received,
        Done
    }
}
