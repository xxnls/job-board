using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace JobBoard.API.Models
{
    public class Person : User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }

        public ICollection<Application> Applications { get; set; }
        public Resume Resume { get; set; } // One-to-One relationship
    }
}
