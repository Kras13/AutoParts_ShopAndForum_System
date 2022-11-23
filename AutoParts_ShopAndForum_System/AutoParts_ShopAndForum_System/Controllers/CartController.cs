using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.Cart;
using AutoParts_ShopAndForum_System.Infrastructure;
using AutoParts_ShopAndForum_System.Models.Cart;
using AutoParts_ShopAndForum_System.Models.Constant;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts_ShopAndForum_System.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Add(ProductCartViewModel model, string lastUrl)
        {
            var cart = HttpContext.Session.GetObject<ICollection<ProductCartModel>>(CartConstant.Cart);

            _cartService.Add(cart, model);

            HttpContext.Session.SetObject(CartConstant.Cart, cart);

            return RedirectToAction("Details", "Products",
                new
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    AddedToCart = true,
                    LastUrl = lastUrl
                });
        }
    }
}
