namespace AutoParts_ShopAndForum.Core.Models.Product
{
    public class ProductQueryModel
    {
        public ICollection<ProductModel> Products { get; set; }

        public int TotalProductsWithoutPagination { get; set; }
    }
}
