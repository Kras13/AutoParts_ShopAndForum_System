using AutoParts_ShopAndForum.Infrastructure.Data.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Models
{
    public class PostCategory
    {
        public PostCategory()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(PostCategoryConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PostCategoryConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
