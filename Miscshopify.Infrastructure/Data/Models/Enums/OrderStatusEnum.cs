using System.ComponentModel.DataAnnotations;

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
