﻿using AutoParts_ShopAndForum.Core.Models.Post;

namespace AutoParts_ShopAndForum.Core.Contracts
{
    public interface IPostService
    {
        void Add(string title, string content, int categoryId, string creatorId);

        PostModel ById(int id);

        ICollection<PostModel> ByCategoryId(int id);

        bool ContainsComment(int postId, int commentId);
    }
}
