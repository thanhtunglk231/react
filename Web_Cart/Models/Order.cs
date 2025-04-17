namespace Web_Cart.Models
{
    public class Order
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ProductId { get; set; }
    }

}
