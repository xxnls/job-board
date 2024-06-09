using System;
using System.Collections.Generic;

namespace JobBoard.Web.Models;

public partial class Person
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public long LocationId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual User IdNavigation { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual Resume? Resume { get; set; }
}
