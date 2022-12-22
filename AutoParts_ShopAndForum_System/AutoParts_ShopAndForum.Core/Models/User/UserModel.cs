using System.Reflection.Metadata.Ecma335;

namespace AutoParts_ShopAndForum.Core.Models.User
{
    public class UserModel
    {
        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string EGN { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Town { get; set; }

        public string Role{ get; set; }
    }
}
