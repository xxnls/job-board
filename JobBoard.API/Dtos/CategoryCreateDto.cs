using System.ComponentModel.DataAnnotations;

namespace JobBoard.API.Dtos
{
    public class CategoryCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
