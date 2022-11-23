using Miscshopify.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Infrastructure.Data.Models
{
    public class MiscshopifyUser
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

        public DateTime CreationDane { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
