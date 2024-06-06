namespace JobBoard.API.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum WorkModel
    {
        Stationary,
        Hybrid,
        Remote
    }

    public enum ContractType
    {
        FullTime,
        PartTime,
        B2B,
        Internship
    }

    [Table("Jobs")]
    public class Job : BaseModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public WorkModel WorkModel { get; set; } 
        [Required]
        public ContractType ContractType { get; set; }
        public decimal? Salary { get; set; }
        public long CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<JobCategory> JobCategories { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
