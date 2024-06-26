﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace JobBoard.API.Models
{
    [Table("Locations")]
    public class Location : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Region { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string City { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string PostalCode { get; set; } = null!;
        [Required]
        [MaxLength(255)]
        public string Address { get; set; } = null!;

        public ICollection<JobLocation> JobLocations { get; set; } = new List<JobLocation>();
        public ICollection<CompanyLocation> CompanyLocations { get; set; } = new List<CompanyLocation>();
    }
}
