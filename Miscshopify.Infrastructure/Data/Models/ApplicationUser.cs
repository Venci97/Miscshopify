using Microsoft.AspNetCore.Identity;
using Miscshopify.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using Miscshopify.Common.Constants;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        public GenderEnum Gender { get; set; }

        [Required]
        [Phone]
        [RegularExpression(GlobalConstants.PhoneNumberRegex)]
        public string PhoneNumber { get; set; }

        public DateTime CreationDane { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
