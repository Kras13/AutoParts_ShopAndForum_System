﻿using AutoParts_ShopAndForum.Core.Models;
using AutoParts_ShopAndForum.Core.Models.Product;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface IProductService
    {
        ProductQueryModel GetQueried(
            int currentPage,
            int productsPerPage,
            string searchCriteria,
            ProductSorting sorting,
            int? categoryId = null,
            ICollection<int> selectedSubcategories = null);
    }
}
