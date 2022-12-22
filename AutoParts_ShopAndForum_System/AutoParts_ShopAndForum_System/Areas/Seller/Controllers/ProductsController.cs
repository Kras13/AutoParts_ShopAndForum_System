using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.Product;
using AutoParts_ShopAndForum.Infrastructure.Data;
using AutoParts_ShopAndForum_System.Areas.Seller.Models;
using AutoParts_ShopAndForum_System.Infrastructure;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Add(ProductAddInputModel model)
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

            _productService.Add(
                 model.Name,
                 model.Price,
                 model.ImageUrl,
                 model.Description,
                 model.SelectedSubcategoryId,
                 this.User.GetId()
             );

            return RedirectToAction("All", "Products", new { area = "" });
        }

        [Authorize(Roles = RoleType.Administrator)]
        public IActionResult Edit(int productId)
        {
            var product = _productService.GetById(productId);
            var model = new ProductAddInputModel()
            {
                ProductId = productId,
                Subcategories = _categoryService.GetAllSubcategories(),
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                SelectedSubcategoryId = product.SubcategoryId
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleType.Administrator)]
        public IActionResult Edit(ProductAddInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model.ProductId);
            }

            _productService.Update(new ProductModel()
            {
                Id = model.ProductId,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                SubcategoryId = model.SelectedSubcategoryId
            });

            return RedirectToAction("All", "Products", new { area = "" });
        }
    }
}
