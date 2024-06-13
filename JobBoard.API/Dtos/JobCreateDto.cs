using JobBoard.API.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobBoard.API.Dtos
{
    public class JobCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Models.WorkModel WorkModel { get; set; }

        [Required]
        public Models.ContractType ContractType { get; set; }

        public decimal? Salary { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public List<int> LocationIds { get; set; } = new List<int>();

        [Required]
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}