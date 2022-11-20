using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.Comment;
using AutoParts_ShopAndForum.Core.Models.Post;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository _repository;

        public PostService(IRepository repository)
        {
            _repository = repository;
        }

        public PostModel ById(int postId)
        {
            var post = this._repository.All<Post>()
                .Include(p => p.Comments)
                .ThenInclude(cp => cp.User)
                .Include(c => c.Creator)
                .FirstOrDefault(p => p.Id == postId);

            if (post == null)
            {
                return null;
            }

            IList<CommentModel> comments = new List<CommentModel>();

            foreach (var comment in post.Comments)
            {
                CommentModel parent = GetCurrentCommentParent(comment, comments);

                comments.Add(new CommentModel()
                {
                    Id = comment.Id,
                    ParentId = comment.ParentId,
                    Parent = parent,
                    Content = comment.Content,
                    CreatorUsername = comment.User.UserName,
                    CreatedOn = comment.CreatedOn.ToString("dd/MM/yyyy")
                });
            }

            return new PostModel()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Comments = comments,
                CreatedOn = ParsePostCreateDate(post.CreatedOn),
                CreatorUserName = post.Creator.UserName
            };
        }

        private string ParsePostCreateDate(DateTime createdOn)
        {
            string pattern = "MM-dd-yy";

            return createdOn.ToString(pattern);
        }

        private CommentModel GetCurrentCommentParent(Comment comment, IList<CommentModel> comments)
        {
            if (comment.Parent == null)
            {
                return null;
            }

            var parentReference = comments.FirstOrDefault(n => n.Id == comment.Parent.Id);

            return parentReference;
        }
    }
}
