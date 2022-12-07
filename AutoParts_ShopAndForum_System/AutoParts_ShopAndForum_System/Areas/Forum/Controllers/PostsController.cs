using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum_System.Areas.Forum.Models;
using AutoParts_ShopAndForum_System.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Areas.Forum.Controllers
{
    public class PostsController : BaseForumController
    {
        private readonly IPostService _postService;
        private readonly IForumCategoryService _categoryService;

        public PostsController(IPostService postService, IForumCategoryService categoryService)
        {
            this._postService = postService;
            _categoryService = categoryService;
        }

        public IActionResult ById(int id)
        {
            var post = _postService.ById(id);

            return View(post);
        }

        public IActionResult List(int categoryId)
        {
            var model = _postService
                .ByCategoryId(categoryId)
                .Select(m => new PostListViewModel() 
                {
                    Id = m.Id,
                    Author = m.CreatorUserName,
                    DateCreate = m.CreatedOn,
                    Title = m.Title,
                    CommentsCount = m.Comments.Count
                }).ToArray();

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new PostInputModel()
            {
                Categories = _categoryService
                .GetAll()
                .Select(c => new PostCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArray()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(PostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoryService
                    .GetAll().
                    Select(c => new PostCategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToArray();

                return View(model);
            }

            _postService.Add(
                model.Title, model.Content, model.PostCategoryId, this.User.GetId());

            return RedirectToAction("All", "Categories", new { area = "Forum" });
        }
    }
}
