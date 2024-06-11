namespace JobBoard.API.Models;

public partial class Application
{
    public long Id { get; set; }

    public long PersonId { get; set; }

    public long JobId { get; set; }

    public long SubmittedResumeId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Resume SubmittedResume { get; set; } = null!;
}
