using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.API.Models
{
    [Table("Resumes")]
    public class Resume : BaseModel
    {
        [Required] 
        public string FilePath { get; set; }
    }
}
