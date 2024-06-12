using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Infrastructure.Data.Models.Enums
{
    public enum PaymentMethodEnum
    {
        [Display(Name = "Card")]
        Card = 1,

        [Display(Name = "Cash on delivery")]
        CashOnDelivery = 2,
    }
}
