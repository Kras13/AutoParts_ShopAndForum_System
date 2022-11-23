using AutoParts_ShopAndForum.Core.Models.Cart;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface ICartService
    {
        bool Add(ICollection<ProductCartModel> Cart, ProductCartModel product);
    }
}
