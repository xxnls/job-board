namespace JobBoard.Web.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public UserDto IdNavigation { get; set; }
    }
}
