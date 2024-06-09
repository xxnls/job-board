using System;
using System.Collections.Generic;

namespace JobBoard.API.Models;

public partial class Job
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string WorkModel { get; set; } = null!;

    public string ContractType { get; set; } = null!;

    public decimal? Salary { get; set; }

    public long CompanyId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual ICollection<Application>? Applications { get; set; } = new List<Application>();

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
