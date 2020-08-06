using ManongTrade.Entity;
using System.ComponentModel.DataAnnotations;

namespace ManongTrade.UI.Shop.Models
{
    public class CustomerModel : Customer
    {
        [Required]
        [StringLength(30)]
        public override string Username { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "First name")]
        public override string Firstname { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Last name")]
        public override string Lastname { get; set; }
    }
}
