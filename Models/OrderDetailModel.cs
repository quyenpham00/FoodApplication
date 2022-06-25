using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodApplication.Models
{
    public class OrderDetailModel
    {
        [Key]
        public Guid OrderDetailId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public double? Discount { get; set; }
        public virtual OrderModel Order { get; set; }
    }

    public class OrderDetailResponse
    {
        public Guid? OrderDetailId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public double? Discount { get; set; }
        public virtual Product Product { get; set; }

        public OrderDetailResponse(OrderDetailModel order)
        {
            OrderDetailId = order.OrderDetailId;
            OrderId = order.OrderId;
            ProductId = order.ProductId;
            Quantity = order.Quantity;
            UnitPrice = order.UnitPrice;
            Discount = order.Discount;
        }
    }
}
