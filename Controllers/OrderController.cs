using FoodApplication.Areas.Identity.Data;
using FoodApplication.Interface;
using FoodApplication.Models.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var discount = await _orderService.Discount(user.Id);
            ViewBag.discount = discount;
            return View();
        }

        public async Task<IActionResult> OrderHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _orderService.GetOrdersByUser(user);
            return View(orders);
        }

        public async Task<IActionResult> OrderDetail(string id)
        {
            var order = await _orderService.GetOrderById(id);
            return View(order);
        }

        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequest orderRequest)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                await _orderService.CreateOrder(orderRequest, user);
                return Ok(new { Status = true });
            }
            catch (Exception e)
            {
                return Ok(new { Status = false, message = e.Message });
            }
        }
        public async Task<IActionResult> Ranking()
        {
            var rankings = await _orderService.GetRanks();
            return View(rankings);
        }
    }
}
