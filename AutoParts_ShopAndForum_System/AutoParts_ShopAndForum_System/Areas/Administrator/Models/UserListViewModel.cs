using AutoParts_ShopAndForum.Core.Models.User;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;

namespace AutoParts_ShopAndForum_System.Areas.Administrator.Models
{
    public class UserListViewModel
    {
        public string Id { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string CurrentUserRole { get; set; }

        public ICollection<string> ActiveRoles { get; set; }
    }
}
