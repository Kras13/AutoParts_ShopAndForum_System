namespace AutoParts_ShopAndForum_System.Areas.Forum.Models
{
    public class CommentInputModel
    {
        public int PostId { get; set; }

        public int ParentId { get; set; }

        public string Content { get; set; }
    }
}
