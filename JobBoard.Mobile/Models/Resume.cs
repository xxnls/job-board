using System;
using System.Collections.Generic;

namespace JobBoard.Mobile.Models;

public partial class Resume
{
    public long Id { get; set; }

    public string FilePath { get; set; } = null!;

    public long PersonId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual Application? Application { get; set; }

    public virtual Person Person { get; set; } = null!;
}
