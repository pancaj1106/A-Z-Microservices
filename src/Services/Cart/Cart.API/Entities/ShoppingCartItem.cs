namespace Cart.API.Entities
{
    public class ShoppingCartItem
    {
        public string Color { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }   
    }
}