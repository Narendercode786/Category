using System.ComponentModel.DataAnnotations;

namespace Category.Domain.Models
{
    public class UserDomain
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
