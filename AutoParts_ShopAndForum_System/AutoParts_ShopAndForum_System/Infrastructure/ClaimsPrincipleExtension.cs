using AutoParts_ShopAndForum.Infrastructure.Data;
using System.Security.Claims;

namespace AutoParts_ShopAndForum_System.Infrastructure
{
    public static class ClaimsPrincipleExtension
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(Role.Administrator);
        }

        public static bool IsSeller(this ClaimsPrincipal user)
        {
            return user.IsInRole(Role.Seller);
        }
    }
}
