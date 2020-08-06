using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManongTrade.UI.Shop.Models.Api
{
    public class LoginModel
    {
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
    }
}
