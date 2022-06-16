namespace FoodApplication.Models
{
    public class OrderModel
    {
        public string OrderId { get; set; }

        public string CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}
