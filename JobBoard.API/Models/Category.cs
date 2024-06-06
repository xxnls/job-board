using System;
using System.Collections.Generic;

namespace JobBoard.API.Models;

public partial class Category
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
