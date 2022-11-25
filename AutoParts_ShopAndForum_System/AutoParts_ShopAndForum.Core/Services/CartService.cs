using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.Cart;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository _repository;
        public CartService(IRepository repository)
        {
            _repository = repository;
        }

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

        public int Order(ref ICollection<ProductCartModel> cart, string userId, string street, int townId)
        {
            var order = new Order();

            using (var transaction = _repository.StartTransaction())
            {
                try
                {
                    order = new Order()
                    {
                        Street = street,
                        DateCreated = System.DateTime.Now,
                        OverallSum = cart.Sum(p => p.Price * p.Quantity),
                        TownId = townId,
                        UserId = userId
                    };

                    _repository.Add<Order>(order);

                    foreach (var product in cart)
                    {
                        order.OrderProducts.Add(new OrderProduct()
                        {
                            ProductId = product.Id,
                            SinglePrice = product.Price,
                            Quantity = product.Quantity
                        });
                    }

                    _repository.SaveChanges();
                    transaction.Commit();
                }
                catch (System.Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }

            if (order.Id > 0)
            {
                cart.Clear();
            }

            return order.Id;
        }
    }
}
