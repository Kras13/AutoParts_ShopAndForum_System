using AutoParts_ShopAndForum.Core.Models.Comment;

namespace AutoParts_ShopAndForum.Core.Models.Post
{
    public class PostModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<CommentModel> Comments { get; set; }

        public string CreatorUserName { get; set; }

        public string CreatedOn { get; set; }
    }
}
