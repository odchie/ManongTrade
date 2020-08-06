using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManongTrade.WebAPI.Model
{
    public class ManongSettingModel
    {
        //public string DBConnection { get; set; }
        public string AuthKey { get; set; }
        public string AuthIssuer { get; set; }
        public string AuthAudience { get; set; }
    }
}
