using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManongTrade.UI.Shop.Models.Api
{
    public class RegisterModel : LoginModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }
    }
}
