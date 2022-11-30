using AutoParts_ShopAndForum.Core.Models.ForumCategory;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface IForumCategoryService
    {
        ICollection<ForumCategoryModel> GetAll();
    }
}
