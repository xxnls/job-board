using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobBoard.API.Models
{
    [Table("Companies")]
    public class Company : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
        [JsonIgnore]
        public ICollection<CompanyLocation> CompanyLocations { get; set; } = new List<CompanyLocation>();
    }
}
