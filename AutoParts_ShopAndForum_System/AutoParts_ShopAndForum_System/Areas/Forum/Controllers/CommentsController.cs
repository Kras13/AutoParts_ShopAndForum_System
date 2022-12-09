using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum_System.Areas.Forum.Models;
using AutoParts_ShopAndForum_System.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Areas.Forum.Controllers
{
    public class CommentsController : BaseForumController
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;

        public CommentsController(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        public IActionResult Create(CommentInputModel model)
        {
            int? parentId = model.ParentId == 0 ? null : model.ParentId;

            if (parentId != null)
            {
                if (!_postService.ContainsComment(model.PostId, parentId.Value))
                {
                    return BadRequest();
                }
            }

            _commentService.Create(this.User.GetId(), model.PostId, model.Content, parentId);

            return this.RedirectToAction("ById", "Posts", new { id = model.PostId });
        }
    }
}
