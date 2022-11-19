using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum_System.Models.Product;
using AutoParts_ShopAndForum_System.Models.Subcategory;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Controllers
{
    public class ProductsController: Controller
    {
        private readonly IProductService _productService;
        private readonly ISubcategoryService _subcategoryService;
        public ProductsController(IProductService productService, ISubcategoryService subcategoryService)
        {
           _productService= productService;
            _subcategoryService= subcategoryService;
        }

        public IActionResult All(ProductQueryViewModel model)
        {
            var queryModel = _productService.GetQueried(
               model.CurrentPage,
               model.ProductsPerPage,
               model.SearchCriteria,
               model.Sorting,
               model.CategoryId,
               model.Subcategories?.Where(sb => sb.Selected).Select(sb => sb.Id).ToArray());

            if (model.Subcategories == null)
            {
                model.Subcategories = _subcategoryService
                    .GetAll(model.CategoryId)
                    .Select(sc => new SubcategorySelectViewModel() { Id = sc.Id, Name = sc.Name })
                    .ToList();
            }

            model.Products = queryModel.Products;
            model.TotalProducts = queryModel.TotalProductsWithoutPagination;

            return View(model);
        }
    }
}
