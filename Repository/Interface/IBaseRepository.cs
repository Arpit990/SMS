using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpeakerManagementSystem.Repository.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetFirst();

        Task<bool> Add(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entities);

        Task<bool> Update(TEntity entity);

        Task Remove(TEntity entity);

        Task<bool> Remove(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Remove<T>(Expression<Func<T, bool>> predicate) where T : class;

        Task RemoveAll(Expression<Func<TEntity, bool>> predicate);
    }
}
