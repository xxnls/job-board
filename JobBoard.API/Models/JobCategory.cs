using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.API.Models
{
    [Table("JobCategories")]
    public class JobCategory : BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}
