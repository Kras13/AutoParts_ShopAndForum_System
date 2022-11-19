using AutoParts_ShopAndForum.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Models
{
    public class PendingSeller
    {
        public PendingSeller()
        {
            Approoved = false;
            DateCandidate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime DateCandidate { get; set; }

        [Required]
        [MaxLength(PendingSellerConstants.SelfDescriptionMaxLength)]
        public string SelfDescription { get; set; }

        public bool Approoved { get; set; }

        [ForeignKey(nameof(ApprovedBy))]
        public string ApprovedById { get; set; }
        public User ApprovedBy { get; set; }
    }
}
