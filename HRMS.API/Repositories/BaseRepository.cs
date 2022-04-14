using HRMS.API.Repositories.IRepositories;
using HRMS.API.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        private readonly IUnitOfWork _IunitOfWork;
        public DbSet<T> _dbSet;

        public BaseRepository(IUnitOfWork IunitOfWork)
        {
            _IunitOfWork = IunitOfWork;
            _dbSet = _IunitOfWork.Context.Set<T>();
        }

        public void Delete(T entity)
        {
            _IunitOfWork.Context.Entry(entity).State = EntityState.Deleted;
            Save();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _IunitOfWork.Context.Entry(entity).State = EntityState.Deleted;
            await SaveAsync();
            return 1;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            return _dbSet.AsNoTracking().Where(filter);
        }

        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<System.Linq.Expressions.Expression<Func<T, object>>> includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<System.Linq.Expressions.Expression<Func<T, object>>> includeProperties, int? page, int? pageSize)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> list = _dbSet.AsNoTracking();
            return list;
        }

        public T Insert(T entity)
        {
            _dbSet.Add(entity);
            Save();
            return entity;
        }

        public async Task<T> InsertAsync(T t)
        {
            await _dbSet.AddAsync(t);
            await SaveAsync();
            return t;
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _IunitOfWork.Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _IunitOfWork.Context.SaveChangesAsync();
        }

        public IQueryable<T> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(T entity)
        {
            _IunitOfWork.Context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
            return entity;
        }

        public void Update(T entity, params System.Linq.Expressions.Expression<Func<T, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> entities, params System.Linq.Expressions.Expression<Func<T, object>>[] properties)
        {
            throw new NotImplementedException();
        }
    }
}
