using System.ComponentModel.DataAnnotations;

namespace Category.Domain.Models
{
    public class CategoryDomain
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be within 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
