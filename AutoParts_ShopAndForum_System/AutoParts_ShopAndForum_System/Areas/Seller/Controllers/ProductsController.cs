using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Services;
using AutoParts_ShopAndForum_System.Areas.Seller.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Areas.Seller.Controllers
{
    public class ProductsController : BaseSellerController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Add()
        {
            var model = new ProductAddInputModel()
            {
                Subcategories = _categoryService.GetAllSubcategories()
            };

            return View(model);
        }
    }
}
