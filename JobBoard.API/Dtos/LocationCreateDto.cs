using System.ComponentModel.DataAnnotations;

namespace JobBoard.API.Dtos
{
    public class LocationCreateDto : BaseModelDto
    {
        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Region { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string City { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string PostalCode { get; set; } = null!;
        [Required]
        [MaxLength(255)]
        public string Address { get; set; } = null!;
    }
}
