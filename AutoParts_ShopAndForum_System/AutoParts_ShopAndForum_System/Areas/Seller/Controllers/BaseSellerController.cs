using AutoParts_ShopAndForum.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Areas.Seller.Controllers
{
    [Area(Role.Seller)]
    [Authorize(Roles = Role.Seller + "," + Role.Administrator)]
    public abstract class BaseSellerController : Controller
    {
    }
}
