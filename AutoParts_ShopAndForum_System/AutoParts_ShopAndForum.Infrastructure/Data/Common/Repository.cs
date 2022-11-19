using Microsoft.EntityFrameworkCore;

namespace AutoParts_ShopAndForum.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public IQueryable<T> AllAsReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsQueryable()
                .AsNoTracking();
        }

        public IQueryable<T> ByIdAsync<T>() where T : class
        {
            throw new NotImplementedException();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }
    }
}
