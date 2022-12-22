using AutoParts_ShopAndForum.Core.Models.User;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface IUserService
    {
        void UpdateUserRole(string userId, string newRoleId);

        ICollection<UserModel> GetAll();

        ICollection<string> GetAllRoles();
    }
}
