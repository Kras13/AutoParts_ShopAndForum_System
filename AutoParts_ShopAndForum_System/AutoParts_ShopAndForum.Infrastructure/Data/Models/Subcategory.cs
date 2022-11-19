using AutoParts_ShopAndForum.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Models
{
    public class Subcategory
    {
        public Subcategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [MaxLength(SubcategoryConstants.NameMaxLength)]
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}