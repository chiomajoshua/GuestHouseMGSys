using DataAccessObjects.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Generic
{
    public class BaseDAO<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseDAO()
        {
            _context = new MyDbContext();
            _context.Configuration.LazyLoadingEnabled = false;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetEntity(Expression<Func<T, bool>> searchParameter, params Expression<Func<T, bool>>[] includePredicates)
        {
            try
            {
                IQueryable<T> filteredlist = _dbSet.AsNoTracking().Where(searchParameter);
                return includePredicates.Aggregate(filteredlist, (current, includeExpression) => current.Include(includeExpression));
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public IEnumerable<T> GetEntities(params Expression<Func<T, object>>[] includePredicates)
        {
            try
            {
                IQueryable<T> tList = _dbSet.AsNoTracking();
                return includePredicates.Aggregate(tList, (current, includeExpression) => current.Include(includeExpression));
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public T CreateEntity(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return entity;
            }

            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public T UpdateEntity(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public void DeleteEntity(long Id)
        {
            try
            {
                T entity = _dbSet.Find(Id);
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }

            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }
    }
}
