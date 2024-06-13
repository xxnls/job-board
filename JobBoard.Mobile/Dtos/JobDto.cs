namespace JobBoard.Mobile.Dtos
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public WorkModel WorkModel { get; set; }
        public ContractType ContractType { get; set; }
        public decimal? Salary { get; set; }
        public string CompanyName { get; set; }  // Denormalized for efficiency

        // Collections for associated data
        public List<string> CategoryNames { get; set; } = new List<string>();
        public List<string> LocationNames { get; set; } = new List<string>();
    }
}
