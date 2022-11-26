using AutoParts_ShopAndForum.Core.Models.Subcaregory;
using AutoParts_ShopAndForum.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace AutoParts_ShopAndForum_System.Areas.Seller.Models
{
    public class ProductAddInputModel
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(ProductConstants.NameMaxLength)]
        [MinLength(2, ErrorMessage = "Please enter at least 2 symbols")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ProductConstants.DescriptionMaxLength)]
        [MinLength(2, ErrorMessage = "Please enter at least 2 symbols")]
        public string Description { get; set; }

        public ICollection<SubcategoryModel>? Subcategories { get; set; }

        [Required]
        [Display(Name = "Subcategory")]
        public int SelectedSubcategoryId { get; set; }

        public string? CreatorId { get; set; }
    }
}
