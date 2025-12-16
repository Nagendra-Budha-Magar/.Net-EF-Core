namespace KYC.Models.Entity
{
    public class Document
    {
        public int Id { get; set; }
        public required string CitizenNumber { get; set; }
        public DateOnly IssueDate { get; set; }
    }
}
