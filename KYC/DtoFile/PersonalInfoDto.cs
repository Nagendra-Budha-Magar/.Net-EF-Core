namespace KYC.DtoFile
{
    public class PersonalInfoDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public DateOnly DateofBirth { get; set; }
        public string? MatrialStatus { get; set; }
        public required string PhoneNo { get; set; }
    }
}
