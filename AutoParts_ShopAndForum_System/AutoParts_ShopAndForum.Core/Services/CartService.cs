using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.Cart;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class CartService : ICartService
    {
        public void Add(ref ICollection<ProductCartModel> cart, ProductCartModel product)
        {
            if (cart == null)
            {
                cart = new List<ProductCartModel>();
            }

            var currentProduct = cart.FirstOrDefault(p => p.Id == product.Id);

            if (currentProduct != null)
            {
                currentProduct.Quantity += product.Quantity;
            }
            else
            {
                cart.Add(product);
            }
        }
    }
}
