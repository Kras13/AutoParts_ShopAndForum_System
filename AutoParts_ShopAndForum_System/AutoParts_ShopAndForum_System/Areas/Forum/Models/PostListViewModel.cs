﻿namespace AutoParts_ShopAndForum_System.Areas.Forum.Models
{
    public class PostListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string DateCreate { get; set; }

        public int CommentsCount { get; set; }
    }
}
