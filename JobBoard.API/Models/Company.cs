using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.API.Models
{
    [Table("Companies")]
    public class Company : User
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyDescription { get; set; }

        public ICollection<Job> Jobs { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
