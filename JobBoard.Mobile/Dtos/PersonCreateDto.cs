using System.ComponentModel.DataAnnotations;

namespace JobBoard.Mobile.Dtos
{
    public class PersonCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(3)]
        public string Password { get; set; } = null!;

        [Required]
        public int LocationId { get; set; }
    }
}
