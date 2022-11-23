namespace Miscshopify.Core.Models
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }

        public IList<ProductOrder> ProductOrder { get; set; } = new List<ProductOrder>();
    }
}
