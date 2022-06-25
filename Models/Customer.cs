using FoodApplication.Areas.Identity.Data;

namespace FoodApplication.Models
{
    public class Customer
    {
        public Customer(ApplicationUser user)
        {
            CustomerName = user.FirstName + user.LastName;
            PhoneNumber = user.PhoneNumber;
        }

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}