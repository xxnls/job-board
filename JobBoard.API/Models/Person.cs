using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.API.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    [Table("People")]
    public class Person : User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public long ResumeId { get; set; }
        public long LocationId { get; set; }

        [ForeignKey("ResumeId")]
        public Resume Resume { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
