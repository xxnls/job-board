using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobBoard.Mobile.Dtos
{
    public enum WorkModel
    {
        Onsite,
        Hybrid,
        Remote
    }

    public enum ContractType
    {
        FullTime,
        PartTime,
        Contract,
        Internship
    }

    public class JobCreateDto
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public WorkModel WorkModel { get; set; }

        [Required]
        public ContractType ContractType { get; set; }

        public decimal? Salary { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public List<int> LocationIds { get; set; } = new List<int>();

        [Required]
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}