using System.Linq.Expressions;

namespace UserForm.Interfaces.IRepositories
{
    public interface IRepository<TEntity, TKeyType> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        int Complete();
    }
}
