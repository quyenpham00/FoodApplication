using FoodApplication.Areas.Identity.Data;
using FoodApplication.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly UserManager<ApplicationUser> _userManager;

        List<int> Months = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public ReportController(IReportService reportService, UserManager<ApplicationUser> userManager)
        {
            _reportService = reportService;
            _userManager = userManager;
        }

        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Index()
        {
            var Orders = await _reportService.GetOrders();
            double total = 0.0;
            foreach (var item in Orders)
            {
                foreach (var order in item.OrderDetails)
                {
                    total += (double)(order.Quantity * order.UnitPrice);
                }
            }
            var listOrdersByTime = Orders.GroupBy(c => c.OrderDate.Value.Month);
            foreach (var item in listOrdersByTime)
            {
                Months[item.Key] = item.Count();
            }
            ViewBag.Revenues = total;
            ViewBag.Goals = ((total / 5000) * 100).ToString("N2");
            ViewData["listdata"] = Months;
            return View();
        }
    }
}
