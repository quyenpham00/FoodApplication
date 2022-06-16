
using FoodApplication.Areas.Identity.Data;

namespace FoodApplication.Models
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }

        public UserViewModel()
        {
        }

        public UserViewModel(ApplicationUser user, List<string> roles)
        {
            this.Id = user.Id;
            this.Name = user.UserName;
            this.Email = user.Email;
            this.Roles = roles;
        }
    }
}