namespace FoodApplication.Models
{
    public class CartModel
    {
        public Guid CartId { get; set; }

        public List<Product>? Products { get; set; }
    }
}
