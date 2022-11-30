using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.ForumCategory;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class ForumCategoryService : IForumCategoryService
    {
        private readonly IRepository _repository;

        public ForumCategoryService(IRepository repository)
        {
            _repository = repository;
        }

        public ICollection<ForumCategoryModel> GetAll()
        {
            return _repository.All<PostCategory>()
                .Include(p => p.Posts)
                .Select(x => new ForumCategoryModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description= x.Description,
                    ImageUrl= x.ImageUrl,
                    PostsCount = x.Posts.Count()
                }).ToArray();
        }
    }
}
