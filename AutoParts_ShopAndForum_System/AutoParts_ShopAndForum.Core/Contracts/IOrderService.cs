using AutoParts_ShopAndForum.Core.Models.Order;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface IOrderService
    {
        ICollection<OrderModel> GetAllByUserId(string userId);
    }
}
