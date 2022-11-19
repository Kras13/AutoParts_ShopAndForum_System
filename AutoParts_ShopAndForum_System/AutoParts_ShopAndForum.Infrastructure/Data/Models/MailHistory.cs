using AutoParts_ShopAndForum.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Models
{
    public class MailHistory
    {
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }
        public User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }
        public User Receiver { get; set; }

        [MaxLength(MailHistoryConstants.ThemeMaxLength)]
        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime SentOn { get; set; }
    }
}