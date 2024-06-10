using System;
using System.Collections.Generic;

namespace JobBoard.Mobile.Models;

public partial class Company
{
    public long Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyDescription { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ProfilePicturePath { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
