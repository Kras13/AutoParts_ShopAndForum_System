using AutoParts_ShopAndForum.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Areas.Forum.Controllers
{
    public class CategoriesController : BaseForumController
    {
        private readonly IForumCategoryService _categoryService;

        public CategoriesController(IForumCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult All()
        {
            var model = _categoryService.GetAll();

            return View(model);
        }
    }
}
