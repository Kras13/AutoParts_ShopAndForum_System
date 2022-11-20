using AutoParts_ShopAndForum.Core.Models.Post;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface IPostService
    {
        public PostModel ById(int id);
    }
}
