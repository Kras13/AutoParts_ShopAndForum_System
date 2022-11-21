using AutoParts_ShopAndForum.Core.Models.Category;
using AutoParts_ShopAndForum.Core.Models.Subcaregory;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface ICategoryService
    {
        ICollection<CategoryModel> GetAll();

        ICollection<SubcategoryModel> GetAllSubcategories();
    }
}
