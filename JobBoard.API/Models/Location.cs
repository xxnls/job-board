using System.ComponentModel.DataAnnotations;

namespace JobBoard.API.Models;

public partial class Location
{
    public long Id { get; set; }

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    public string Region { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    [Required]
    public string PostalCode { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
