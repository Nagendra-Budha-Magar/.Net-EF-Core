namespace KYC.DtoFile
{
    public class UpdatePersonalInfoDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public string? MatrialStatus { get; set; }
        public required string PhoneNo { get; set; }
    }
}
