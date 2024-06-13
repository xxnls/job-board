using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.API.Models
{
    public class CompanyLocation
    {
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
