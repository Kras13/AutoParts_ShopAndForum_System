using AutoParts_ShopAndForum.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Areas.Forum.Controllers
{
    public class PostsController : BaseForumController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            this._postService = postService;
        }

        public IActionResult ById(int id)
        {
            var post = _postService.ById(id);

            return View(post);
        }
    }
}
