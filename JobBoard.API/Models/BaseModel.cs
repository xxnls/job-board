using System.ComponentModel.DataAnnotations;

namespace JobBoard.API.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

    }
}
