using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.Subcaregory;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly IRepository _repository;
        public SubcategoryService(IRepository repository)
        {
            _repository = repository;
        }

        public ICollection<SubcategoryModel> GetAll(int? categoryId = null)
        {
            var result = _repository
                .AllAsReadOnly<Subcategory>();

            if (categoryId.HasValue)
            {
                result = result.Where(c => c.CategoryId == categoryId);
            }

            return result
                .Select(sc => new SubcategoryModel() { Id = sc.Id, Name = sc.Name })
                .ToArray();
        }
    }
}
