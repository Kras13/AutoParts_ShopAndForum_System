﻿namespace AutoParts_ShopAndForum.Core.Models.Comment
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int? ParentId { get; set; }

        public CommentModel Parent { get; set; }

        public string CreatorUsername { get; set; }

        public string CreatedOn { get; set; }
    }
}
