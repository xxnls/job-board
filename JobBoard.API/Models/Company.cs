using System.ComponentModel.DataAnnotations;

namespace JobBoard.API.Models
{
    public class Company : User
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyDescription { get; set; }
    }
}
