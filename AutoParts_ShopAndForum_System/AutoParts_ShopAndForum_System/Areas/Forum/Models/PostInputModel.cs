using System.ComponentModel.DataAnnotations;

namespace AutoParts_ShopAndForum_System.Areas.Forum.Models
{
    public class PostInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }


        [Required]
        public int PostCategoryId { get; set; }

        public string CreatorId { get; set; }

        public ICollection<PostCategoryViewModel> Categories { get; set; }
    }
}
