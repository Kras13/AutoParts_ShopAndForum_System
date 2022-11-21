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

        private DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }

        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
