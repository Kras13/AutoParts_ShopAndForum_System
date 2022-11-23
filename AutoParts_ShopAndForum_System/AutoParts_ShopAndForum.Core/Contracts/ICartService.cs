using AutoParts_ShopAndForum.Core.Models.Cart;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface ICartService
    {
        void Add(ref ICollection<ProductCartModel> cart, ProductCartModel product);
    }
}
