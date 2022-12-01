using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
