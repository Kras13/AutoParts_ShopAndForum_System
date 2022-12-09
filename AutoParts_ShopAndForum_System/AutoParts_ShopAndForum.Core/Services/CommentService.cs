using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository _repository;

        public CommentService(IRepository repository)
        {
            _repository = repository;
        }

        public void Create(string userId, int postId, string content, int? parentId = null)
        {
            var comment = new Comment()
            {
                PostId = postId,
                ParentId = parentId,
                Content= content,
                CreatedOn = DateTime.UtcNow,
                UserId = userId
            };

            _repository.Add(comment);
            _repository.SaveChanges();
        }
    }
}
