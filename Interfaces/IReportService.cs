using FoodApplication.Areas.Identity.Data;
using FoodApplication.Models;
using FoodApplication.Models.Requests;

namespace FoodApplication.Interface
{
    public interface IReportService
    {
        Task<List<OrderResponse>> GetOrders();
    }
}
