using FoodApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodApplication.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetUsers();
        Task<List<IdentityRole>> GetAllRoles();
    }
    
}
