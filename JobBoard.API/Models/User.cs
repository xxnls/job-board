using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobBoard.API.Models
{
    [Table("Users")]
    public class User : BaseModel
    {
        public string UserName { get; set; } = null!;
        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(3)]
        public string Password { get; set; } = null!;
        public string? ProfilePicturePath { get; set; }
        [JsonIgnore]
        public Person? Person { get; set; }
        [JsonIgnore]
        public Company? Company { get; set; }
    }
}
