using System.ComponentModel.DataAnnotations;

namespace Miscshopify.Infrastructure.Data.Models.Enums
{
	public enum GenderEnum
    {
		[Display(Name = "Male")]
		Male = 1,

		[Display(Name = "Female")]
		Female = 2,
    }
}
