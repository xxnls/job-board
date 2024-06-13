using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.API.Models
{
    [Table("People")]
    public class Person : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;
        public int UserId { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; } = null!;
    }
}
