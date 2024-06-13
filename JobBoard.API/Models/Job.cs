using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.API.Models
{
    public enum WorkModel
    {
        OnSite,
        Remote,
        Hybrid
    }

    public enum ContractType
    {
        FullTime,
        PartTime,
        Contract,
        Internship
    }

    [Table("Jobs")]
    public class Job : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public WorkModel WorkModel { get; set; }
        [Required]
        public ContractType ContractType { get; set; }
        public decimal? Salary { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public ICollection<JobLocation> JobLocations { get; set; } = new List<JobLocation>();
        public ICollection<JobCategory> JobCategories { get; set; } = new List<JobCategory>();
    }
}
