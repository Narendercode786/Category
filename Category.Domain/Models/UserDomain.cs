using System.ComponentModel.DataAnnotations;

namespace Category.Domain.Models
{
    public class UserDomain
    {
        [Required]
        [Display(Name = "User Id")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
