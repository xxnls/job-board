using System.ComponentModel.DataAnnotations;

namespace JobBoard.API.Models
{
    public class JobCategory : BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}
