namespace JobBoard.API.Models
{
    using System.ComponentModel.DataAnnotations;
    using static System.Net.Mime.MediaTypeNames;

    public class Job : BaseModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<JobCategory> JobCategories { get; set; }
    }
}
