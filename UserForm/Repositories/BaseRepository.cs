using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserForm.Interfaces.IRepositories;

namespace UserForm.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : class
    {
        protected readonly DbSet<TEntity> dbSet;
        protected readonly UserFormDbContext _context;

        public BaseRepository(UserFormDbContext context)
        {
            _context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public async Task Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
