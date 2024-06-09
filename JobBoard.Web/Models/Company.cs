using System;
using System.Collections.Generic;

namespace JobBoard.Web.Models;

public partial class Company
{
    public long Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyDescription { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
