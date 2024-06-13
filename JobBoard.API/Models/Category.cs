using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.API.Models
{
    [Table("Categories")]
    public class Category : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<JobCategory> JobCategories { get; set; } = new List<JobCategory>();
    }
}
