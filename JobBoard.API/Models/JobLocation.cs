using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobBoard.API.Models
{
    public class JobLocation
    {
        public int JobId { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("JobId")]
        [JsonIgnore]
        public Job Job { get; set; } = null!;
        [ForeignKey("LocationId")]
        public Location Location { get; set; } = null!;
    }
}
