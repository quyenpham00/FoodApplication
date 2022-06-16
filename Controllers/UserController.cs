using FoodApplication.Areas.Identity.Data;
using FoodApplication.Interfaces;
using FoodApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            IList<UserViewModel> listUser = await _userService.GetUsers();
            return View(listUser);
        }
    }
}
