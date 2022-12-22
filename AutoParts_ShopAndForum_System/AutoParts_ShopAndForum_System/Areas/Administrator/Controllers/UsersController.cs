using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.User;
using AutoParts_ShopAndForum_System.Areas.Administrator.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Areas.Administrator.Controllers
{
    public class UsersController : BaseAdministratorController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult List()
        {
            var model = _userService
                .GetAll()
                .Select(m => new UserListViewModel()
                {
                    Id = m.Id,
                    Fullname = m.Firstname = m.Lastname,
                    Email = m.Email,
                    CurrentUserRole = m.Role,
                    ActiveRoles = _userService.GetAllRoles()
                }).ToArray();

            return View(model);
        }
    }
}
