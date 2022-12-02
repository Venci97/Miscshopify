using Microsoft.AspNetCore.Identity;
using Miscshopify.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using Miscshopify.Common.Constants;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string ImagePath { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        public GenderEnum Gender { get; set; }

        [Required]
        [Phone]
        [RegularExpression(GlobalConstants.Regex.PhoneNumberRegex)]
        public override string PhoneNumber { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

    }
}
