using System;
using System.Collections.Generic;

namespace JobBoard.API.Models;

public partial class User
{
    public long Id { get; set; }

    public string? Username { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? ProfilePicturePath { get; set; }

    public virtual Company? Company { get; set; }

    public virtual Person? Person { get; set; }
}
