using AutoParts_ShopAndForum.Core.Models.Category;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface ICategoryService
    {
        ICollection<CategoryModel> GetAll();
    }
}
