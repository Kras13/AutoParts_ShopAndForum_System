﻿using AutoParts_ShopAndForum.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Models
{
    public class Town
    {
        public Town()
        {
            Users = new HashSet<User>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(TownConstants.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
