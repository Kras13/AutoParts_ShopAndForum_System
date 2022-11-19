using AutoParts_ShopAndForum.Core.Models.Product;
using AutoParts_ShopAndForum.Core.Models;
using AutoParts_ShopAndForum_System.Models.Subcategory;

namespace AutoParts_ShopAndForum_System.Models.Product
{
    public class ProductQueryViewModel
    {
        public int CurrentPage { get; set; } = 1;

        public int ProductsPerPage { get; set; } = 2;

        public int TotalProducts { get; set; }

        public string SearchCriteria { get; set; }

        public ProductSorting Sorting { get; set; }

        public int? CategoryId { get; set; }

        public string CurrentUrl { get; set; }

        public ICollection<ProductModel> Products { get; set; }

        public List<SubcategorySelectViewModel> Subcategories { get; set; }
    }
}
