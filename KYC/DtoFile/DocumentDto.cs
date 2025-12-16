namespace KYC.DtoFile
{
    public class DocumentDto
    {
        public required string CitizenNumber { get; set; }
        public DateOnly IssueDate { get; set; }
    }
}
