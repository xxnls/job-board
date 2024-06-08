namespace JobBoard.Web.Dtos
{
    public class JobDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string WorkModel { get; set; }
        public string ContractType { get; set; }
        public decimal? Salary { get; set; }

        // properties from related entities (but not the whole objects)
        public string CompanyName { get; set; }
        public IEnumerable<string> Categories { get; set; } // Names of the categories
        public IEnumerable<string> Locations { get; set; }   // Location details (e.g., City, State)
    }
}
