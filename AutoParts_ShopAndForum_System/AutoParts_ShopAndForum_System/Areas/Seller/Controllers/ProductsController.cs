using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum_System.Areas.Seller.Models;
using AutoParts_ShopAndForum_System.Infrastructure;
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

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddInputModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Subcategories = _categoryService.GetAllSubcategories();
                return View(model);
            }

            if (!this.User.IsAdmin() && !this.User.IsSeller())
            {
                throw new InvalidOperationException("Products/Add -> Only Sellers and Admins can add products");
            }

            await _productService.AddAsync(
                model.Name,
                model.Price,
                model.ImageUrl,
                model.Description,
                model.SelectedSubcategoryId,
                this.User.GetId()
            );

            return RedirectToAction("All", "Products", new { area = "" });
        }
    }
}
