namespace FoodApplication.Models
{
    public class CartModel
    {
        public string CartId { get; set; }

        public List<Product>? Products { get; set; }
    }
}
