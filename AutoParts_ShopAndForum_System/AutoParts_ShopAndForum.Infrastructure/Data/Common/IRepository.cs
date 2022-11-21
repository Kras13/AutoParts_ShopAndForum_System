﻿namespace AutoParts_ShopAndForum.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllAsReadOnly<T>() where T : class;

        Task<T> GetByIdAsync<T>(object id) where T : class;

        public Task AddAsync<T>(T entity) where T : class;

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
