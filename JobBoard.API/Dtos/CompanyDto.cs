namespace JobBoard.API.Dtos
{
    public class CompanyDto
    {
        //public long Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string CompanyDescription { get; set; } = null!;
        public IEnumerable<string> Locations { get; set; }
        public ICollection<JobDto> Jobs { get; set; }
    }
}
