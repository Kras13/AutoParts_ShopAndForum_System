using AutoParts_ShopAndForum.Core.Models.Product;
using AutoParts_ShopAndForum.Core.Models;
using AutoParts_ShopAndForum_System.Models.Subcategory;
using AutoParts_ShopAndForum_System.Models.Pagination;
using AutoParts_ShopAndForum.Core.Services;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace AutoParts_ShopAndForum_System.Models.Product
{
    public class ProductQueryViewModel
    {
        public ProductQueryViewModel()
        {
            Pages = new List<PageViewModel>()
            {
                new PageViewModel() {DisplayText = "2", PageIndex = 2},
                new PageViewModel() {DisplayText = "3", PageIndex = 3},
                new PageViewModel() {DisplayText = "10", PageIndex = 10},
                new PageViewModel() {DisplayText = "Всички", PageIndex = ProductService.AllProducts}
            };

            Sortings = new List<SortingViewModel>()
            {
                new SortingViewModel() {DisplayText = "No sorting", Sorting = ProductSorting.NoSorting},
                new SortingViewModel() {DisplayText = "Price ascending", Sorting = ProductSorting.PriceAscending},
                new SortingViewModel() {DisplayText = "Price descending", Sorting = ProductSorting.PriceDescending},
                new SortingViewModel() {DisplayText = "Name ascending", Sorting = ProductSorting.NameAscending},
                new SortingViewModel() {DisplayText = "Name descending", Sorting = ProductSorting.NameDescending},
                new SortingViewModel() {DisplayText = "Date added ascending", Sorting = ProductSorting.DateAscenging},
                new SortingViewModel() {DisplayText = "Date added descending", Sorting = ProductSorting.DateDescending},

            };
        }

        public int CurrentPage { get; set; } = 1;

        public ICollection<PageViewModel> Pages { get; set; }

        public int ProductsPerPage { get; set; } = 2;

        public int TotalProducts { get; set; }

        public string SearchCriteria { get; set; }

        public ProductSorting Sorting { get; set; }

        public ICollection<SortingViewModel> Sortings { get; set; }

        public int? CategoryId { get; set; }

        public string CurrentUrl { get; set; }

        public ICollection<ProductModel> Products { get; set; }

        public List<SubcategorySelectViewModel> Subcategories { get; set; }
    }
}
