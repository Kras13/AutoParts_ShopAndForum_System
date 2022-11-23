using AutoParts_ShopAndForum.Core.Models.Product;
using AutoParts_ShopAndForum.Core.Models.Town;
using AutoParts_ShopAndForum_System.Models.Product;
using System.ComponentModel;

namespace AutoParts_ShopAndForum_System.Models.Cart
{
    public class CartListViewModel
    {
        public ICollection<ProductDetailsViewModel> Products { get; set; }

        public string LastUrl { get; set; }

        [DisplayName("Town")]
        public ICollection<TownModel> Towns { get; set; }

        public int SelectedTownId { get; set; }
    }
}
