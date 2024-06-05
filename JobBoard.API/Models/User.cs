using System.ComponentModel.DataAnnotations;

namespace JobBoard.API.Models
{
    public class User : BaseModel
    {
        public string? Username { get; set; } // will be generated automatically
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Password { get; set; }
        [Required]
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
