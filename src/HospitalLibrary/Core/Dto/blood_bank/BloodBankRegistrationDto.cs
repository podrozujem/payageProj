using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HospitalLibrary.Dto.blood_bank
{
    public class BloodBankRegistrationDto
    {
        [NotNull]
        [Required]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Field Cannot be Blank Or Whitespace")]
        public string CompanyName { get; set; }
        [NotNull]
        [Required]
        [EmailAddress]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Field Cannot be Blank Or Whitespace")]
        public string Email { get; set; }
        [NotNull]
        [Required]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Field Cannot be Blank Or Whitespace")]
        public string ServerAddress { get; set; }
    }
}
