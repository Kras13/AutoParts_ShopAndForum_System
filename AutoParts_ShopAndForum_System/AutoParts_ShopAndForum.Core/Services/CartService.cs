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

        public void ChangeQuantity(ref ICollection<ProductCartModel> cart, int productId, int quantity)
        {
            var product = cart.FirstOrDefault(m => m.Id == productId);

            if (product == null)
            {
                throw new ArgumentException("CartService.ChangeQuantity -> Invalid productId");
            }

            product.Quantity = quantity;
        }
    }
}
