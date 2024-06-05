namespace JobBoard.API.Models
{
    public class Application : BaseModel
    {
        public int UserId { get; set; }
        public int JobId { get; set; }

        public User User { get; set; }
        public Job Job { get; set; }
    }
}
