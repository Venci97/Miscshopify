namespace Miscshopify.Core.Models
{
    public class CustomerOrderViewModel
    {
        public int CustomerId { get; set; }

        public IList<CartItemViewModel> ProductOrder { get; set; } = new List<CartItemViewModel>();
    }
}
