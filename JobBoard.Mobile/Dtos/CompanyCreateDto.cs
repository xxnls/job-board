using System.ComponentModel.DataAnnotations;

namespace JobBoard.Mobile.Dtos
{
    public class CompanyCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public List<int> LocationIds { get; set; } = new List<int>();
    }
}
