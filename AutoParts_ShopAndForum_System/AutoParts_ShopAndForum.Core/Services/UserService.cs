using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.User;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IRepository repository, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public ICollection<UserModel> GetAll()
        {
            // TODO -> think of more clear version

            var roles = _repository.All<IdentityUserRole<string>>()
                .ToDictionary(c => c.UserId);

            return _userManager
                .Users
                .Include(e => e.Town)
                .Select(e => new UserModel()
                {
                    Id = e.Id,
                    EGN= e.EGN,
                    Email= e.Email,
                    Firstname= e.FirstName,
                    Lastname= e.LastName,
                    PhoneNumber= e.PhoneNumber,
                    Town = e.Town.Name,
                    Role =  _userManager.GetRolesAsync(e).Result.FirstOrDefault()
                }).ToArray();
        }

        public ICollection<string> GetAllRoles()
        {
            return _roleManager.Roles
                .Select(e => e.Name)
                .ToArray();
        }

        public void UpdateUserRole(string userId, string newRoleName)
        {
            var user = _userManager.Users
                .FirstOrDefault(e => e.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("UserService.UpdateUserRole -> Inexistant user");
            }

            var newRole = _roleManager.FindByNameAsync(newRoleName).GetAwaiter().GetResult();

            if (newRole == null)
            {
                throw new ArgumentException("UserService.UpdateUserRole -> Inexistant role");
            }

            Task.Run(async () =>
            {
                var currentUserRoles = await _userManager.GetRolesAsync(user);

                await _userManager.RemoveFromRolesAsync(user, currentUserRoles);
                await _userManager.AddToRoleAsync(user, newRole.Name);
            });
        }
    }
}
