using AutoParts_ShopAndForum.Core.Models.Comment;
using Ganss.XSS;

namespace AutoParts_ShopAndForum.Core.Models.Post
{
    public class PostModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitaziedContent
        {
            get
            {
                return new HtmlSanitizer().Sanitize(this.Content);
            }
        }

        public ICollection<CommentModel> Comments { get; set; }

        public string CreatorUserName { get; set; }

        public string CreatedOn { get; set; }
    }
}
