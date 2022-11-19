using AutoParts_ShopAndForum.Infrastructure.Data.Constants;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            MessagesSent = new HashSet<MailHistory>();
            MessagesReceived = new HashSet<MailHistory>();
            Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(UserConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(UserConstants.NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(UserConstants.EGNMaxLength)]
        public string EGN { get; set; }

        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Product> Products { get; set; }

        public virtual ICollection<MailHistory> MessagesSent { get; set; }

        public virtual ICollection<MailHistory> MessagesReceived { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
