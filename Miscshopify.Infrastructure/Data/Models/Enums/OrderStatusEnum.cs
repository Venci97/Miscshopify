using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Miscshopify.Infrastructure.Data.Models.Enums
{
    public enum OrderStatusEnum
    {
        [Display(Name = "Pending")]
        Pending = 1,

        [Display(Name = "On the way")]
        OnTheWay = 2,

        [Display(Name = "Comleted")]
        Completed = 3,
    }
}
