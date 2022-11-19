using AutoParts_ShopAndForum.Core.Models.Subcaregory;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface ISubcategoryService
    {
        ICollection<SubcategoryModel> GetAll(int? categoryId = null);
    }
}
