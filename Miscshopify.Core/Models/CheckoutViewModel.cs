using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using System.Collections.Generic;

public class CheckoutViewModel
{
    public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

    public decimal TotalPrice { get; set; }
    public int TotalQuantity { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserCity { get; set; }
    public string UserAddress { get; set; }
    public string UserPostCode { get; set; }
    public string UserPhoneNumber { get; set; }
    public string PaymentMethod { get; set; }
}
