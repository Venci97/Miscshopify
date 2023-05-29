using Miscshopify.Infrastructure.Data.Models.Enums;

namespace Miscshopify.Core.Models
{
	public class UserEditViewModel
	{
		public string Id { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public GenderEnum Gender { get; set; }

		public bool IsActive { get; set; }
	}
}
