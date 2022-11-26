using AutoParts_ShopAndForum.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Areas.Administrator.Controllers
{
    [Area(Role.Administrator)]
    [Authorize(Roles = Role.Administrator)]
    public abstract class BaseAdministratorController : Controller
    {
    }
}
