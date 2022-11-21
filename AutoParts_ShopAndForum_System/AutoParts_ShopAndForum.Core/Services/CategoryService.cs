using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.Category;
using AutoParts_ShopAndForum.Core.Models.Subcaregory;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository _repository;

        public CategoryService(IRepository repository)
        {
            _repository = repository;
        }

        public ICollection<CategoryModel> GetAll()
        {
            return _repository
                .All<Category>()
                .Select(m => new CategoryModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl
                }
                )
                .ToArray();
        }

        public ICollection<SubcategoryModel> GetAllSubcategories()
        {
            return _repository.All<Subcategory>()
                .Select(m => new SubcategoryModel() { Id = m.Id, Name = m.Name })
                .ToArray();
        }
    }
}
