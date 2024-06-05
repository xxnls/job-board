using System.ComponentModel.DataAnnotations;

namespace JobBoard.API.Models
{
    public class Resume : BaseModel
    {
        [Required] 
        public string FilePath { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
