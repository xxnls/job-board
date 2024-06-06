using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.API.Models
{
    [Table("Applications")]
    public class Application : BaseModel
    {
        public int PersonId { get; set; }
        public int SubmittedResumeId { get; set; }
        public int JobId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        [ForeignKey("SubmittedResumeId")]
        public Resume SubmittedResume { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }
    }
}
