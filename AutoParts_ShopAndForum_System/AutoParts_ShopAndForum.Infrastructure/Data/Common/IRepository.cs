using System.Linq.Expressions;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllAsReadOnly<T>() where T : class;

        IQueryable<T> ByIdAsync<T>() where T : class;
    }
}
