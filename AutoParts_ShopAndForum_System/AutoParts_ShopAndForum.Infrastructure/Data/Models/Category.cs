using AutoParts_ShopAndForum.Infrastructure.Data.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Models
{
    public class Category
    {
        public Category()
        {
            SubCategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Subcategory> SubCategories { get; set; }
    }
}
