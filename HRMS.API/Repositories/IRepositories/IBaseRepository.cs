using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRMS.API.Repositories.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Find(params object[] keyValues);

        Task<T> FindAsync(params object[] keyValues);

        IQueryable<T> SelectQuery(string query, params object[] parameters);

        T Insert(T entity);

        Task<T> InsertAsync(T entity);

        void InsertRange(IEnumerable<T> entities);

        Task<T> Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Update(T entity, params Expression<Func<T, object>>[] properties);

        void UpdateRange(IEnumerable<T> entities, params Expression<Func<T, object>>[] properties);

        void Delete(T entity);

        Task<int> DeleteAsync(T entity);

        void DeleteRange(IEnumerable<T> entities);

        IQueryable<T> GetAll();

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);

        IQueryable<T> Get(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);

        IQueryable<T> Get(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            List<Expression<Func<T, object>>> includeProperties);

        IQueryable<T> Get(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            List<Expression<Func<T, object>>> includeProperties,
            int? page,
            int? pageSize);

        void Save();

        Task SaveAsync();
    }
}
