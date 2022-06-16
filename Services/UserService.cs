using FoodApplication.Areas.Identity.Data;
using FoodApplication.Interfaces;
using FoodApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoodApplication.Data
{

    public class UserService : IUserService
    {
        private readonly AuthContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(AuthContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<UserViewModel>> GetUsers()
        {
            var users = await _userManager.Users.Select(c => new UserViewModel()
            {
                Id = c.Id,
                Name = c.UserName,
                Email = c.Email,
                Roles = _userManager.GetRolesAsync(c).Result.ToList()
            }).ToListAsync();
            return users;
        }

        public async Task<List<IdentityRole>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
