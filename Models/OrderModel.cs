using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Models
{
    public class OrderModel
    {
        [Key]
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Notes { get; set; }
        public virtual ICollection<OrderDetailModel> OrderDetails { get; set; }

        public OrderModel()
        {
        }

        public OrderModel(OrderModel order)
        {
            OrderId = order.OrderId;
            CustomerId = order.CustomerId;
            OrderDate = order.OrderDate;
            CustomerName = order.CustomerName;
            CustomerAddress = order.CustomerAddress;
            PhoneNumber = order.PhoneNumber;
            Notes = order.Notes;
        }
    }

    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Notes { get; set; }
        public virtual ICollection<OrderDetailResponse> OrderDetails { get; set; }

        public OrderResponse(OrderModel order)
        {
            OrderId = order.OrderId;
            OrderDate = order.OrderDate;
            CustomerName = order.CustomerName;
            CustomerAddress = order.CustomerAddress;
            PhoneNumber = order.PhoneNumber;
            Notes = order.Notes;
            if (order.OrderDetails != null)
            {
                OrderDetails = order.OrderDetails
                    .Select(c =>
                {
                    return new OrderDetailResponse(c);
                }).ToList();
            }
        }
    }
}
