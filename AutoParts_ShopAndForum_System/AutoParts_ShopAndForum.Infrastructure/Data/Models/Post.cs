using AutoParts_ShopAndForum.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(PostConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(PostConstants.ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        [ForeignKey(nameof(Creator))]
        public string CraetorId { get; set; }
        public User Creator { get; set; }

        [ForeignKey(nameof(PostCategory))]
        public int PostCategoryId { get; set; }
        public PostCategory PostCategory { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
