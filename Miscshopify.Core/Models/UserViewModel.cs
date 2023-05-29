using Miscshopify.Infrastructure.Data.Models.Enums;

namespace Miscshopify.Core.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string ImagePath { get; set; }

        public string Name { get; set; }

        public string Email { get; set; } 

        public string PhoneNumber { get; set; }

        public GenderEnum Gender { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }
    }
}
