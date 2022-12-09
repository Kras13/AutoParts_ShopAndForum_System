using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.Comment;
using AutoParts_ShopAndForum.Core.Models.Post;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository _repository;

        public PostService(IRepository repository)
        {
            _repository = repository;
        }
        public void Add(string title, string content, int categoryId, string creatorId)
        {
            var post = new Post()
            {
                Title = title,
                Content = content,
                CreatedOn = DateTime.UtcNow,
                PostCategoryId = categoryId,
                CraetorId = creatorId
            };

            _repository.Add(post);

            _repository.SaveChanges();
        }

        public PostModel ById(int postId)
        {
            var post = this._repository
                .AllAsReadOnly<Post>()
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

        public ICollection<PostModel> ByCategoryId(int id)
        {
            return _repository
                .All<Post>()
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .Where(e => e.PostCategoryId == id)
                .Select(e => new PostModel()
                {
                    Id = e.Id,
                    Title = e.Title,
                    Content = e.Content,
                    CreatedOn = e.CreatedOn.ToShortDateString(),
                    CreatorUserName = e.Creator.UserName,
                    Comments = e.Comments.Select(c =>
                        new CommentModel()
                        {
                            Id = c.Id,
                            ParentId = c.ParentId,
                            Content= c.Content,
                            CreatedOn = c.CreatedOn.ToShortDateString(),
                            CreatorUsername = c.User.UserName
                        }).ToArray()
                }).ToArray();
        }

        public bool ContainsComment(int postId, int commentId)
        {
            var post = _repository.All<Post>()
                .Include(p => p.Comments)
                .FirstOrDefault(e => e.Id == postId);

            if (post == null)
            {
                throw new ArgumentException("PostService.ContainsComment -> Post does not exist");
            }

            return post.Comments.FirstOrDefault(e => e.Id == commentId) != null;
        }
    }
}
