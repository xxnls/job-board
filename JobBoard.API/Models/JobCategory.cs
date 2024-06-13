using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobBoard.API.Models
{
    public class JobCategory
    {
        public int JobId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("JobId")]
        [JsonIgnore]
        public Job Job { get; set; } = null!;
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
    }
}
