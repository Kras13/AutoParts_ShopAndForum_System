namespace AutoParts_ShopAndForum.Core.Models.ForumCategory
{
    public class ForumCategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }
    }
}
