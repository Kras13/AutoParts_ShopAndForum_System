using AutoParts_ShopAndForum.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();

            return View(categories);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}