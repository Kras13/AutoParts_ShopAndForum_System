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
        private readonly ITownService _townService;
        public CartController(ICartService cartService, ITownService townService)
        {
            _cartService = cartService;
            _townService = townService;
        }

        public IActionResult Add(ProductCartModel model, string lastUrl)
        {
            var cart = HttpContext.Session.GetObject<ICollection<ProductCartModel>>(CartConstant.Cart);

            _cartService.Add(ref cart, model);

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

        public IActionResult All()
        {
            var products = HttpContext.Session.GetObject<ICollection<ProductCartModel>>(CartConstant.Cart);

            var model = new CartListViewModel()
            {
                Products = products,
                Towns = _townService.GetAll()
            };

            return View(model);
        }

        public void ChangeProduct(int id, int quantity)
        {
            var cart = HttpContext.Session.GetObject<ICollection<ProductCartModel>>(CartConstant.Cart);

            _cartService.ChangeQuantity(ref cart, id, quantity);

            HttpContext.Session.SetObject(CartConstant.Cart, cart);
        }

        public void RemoveProduct(int id)
        {
            var cartCollection = HttpContext.Session.GetObject<ICollection<ProductCartModel>>(CartConstant.Cart);

            var selectedModel = cartCollection.FirstOrDefault(m => m.Id == id);

            cartCollection.Remove(selectedModel);

            HttpContext.Session.SetObject(CartConstant.Cart, cartCollection);
        }
    }
}
