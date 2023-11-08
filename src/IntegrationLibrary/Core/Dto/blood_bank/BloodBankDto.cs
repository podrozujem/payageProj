using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Dto.blood_bank
{
    public class BloodBankDto
    {
        public int BloodBankId { get; set; }
        public int UserId { get; set; }
        [NotNull]
        [Required]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Field Cannot be Blank Or Whitespace")]
        public string CompanyName { get; set; }
        [NotNull]
        [Required]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Field Cannot be Blank Or Whitespace")]
        public string ServerAddress { get; set; }
        public string ApiKey { get; set; }
    }
}
