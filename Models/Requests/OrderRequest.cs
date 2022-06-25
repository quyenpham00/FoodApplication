namespace FoodApplication.Models.Requests
{
    public class OrderRequest
    {
        public string? CustomerName { get; set; }
        public string? CustomerAddress{ get; set; }
        public string? PhoneNumber { get; set; }
        public string? Notes { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public double Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
