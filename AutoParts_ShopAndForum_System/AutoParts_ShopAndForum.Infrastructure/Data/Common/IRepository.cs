using Microsoft.EntityFrameworkCore.Storage;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllAsReadOnly<T>() where T : class;

        Task<T> GetByIdAsync<T>(object id) where T : class;

        public void Add<T>(T entity) where T : class;

        void SaveChanges();

        Task SaveChangesAsync();

        IDbContextTransaction StartTransaction();
    }
}
