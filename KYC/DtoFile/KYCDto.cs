using KYC.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace KYC.DtoFile
{
    public class KYCDto
    {
        [Required]
        public PersonalInfoDto PersonalInfo { get; set; }
        [Required]
        public GuardianDto Guardian { get; set; }
        [Required]
        public DocumentDto Document { get; set; }

    }
}
