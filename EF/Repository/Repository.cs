using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace EF.Repository
{
    [ExcludeFromCodeCoverage]
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbcontext;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext dbcontext)
        {
            this._dbcontext = dbcontext;
            this._entities = dbcontext.Set<TEntity>();
        }

        // Include lambda expressions in queries
        private IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties,
                                                IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IRepository<TEntity> Members

        public IQueryable<TEntity> AsQueryable()
        {
            return _entities.AsQueryable<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            return PerformInclusions(includeProperties, query);
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = AsQueryable();
            return await query.FirstAsync(predicate);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public int? Max(Func<TEntity, int?> selector)
        {
            IQueryable<TEntity> query = AsQueryable();
            return query.Max(selector);
        }

        public int? Min(Func<TEntity, int?> selector)
        {
            IQueryable<TEntity> query = AsQueryable();
            return query.Min(selector);
        }

        public async Task<TEntity> First(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return await query.FirstAsync(where);
        }

        public TEntity Last(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Last(where);
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return await query.FirstOrDefaultAsync(where);
        }

        public async Task<TEntity> LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return await query.LastOrDefaultAsync(where);
        }

        public async Task<TEntity> Single(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return await query.SingleAsync(where);
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return await query.SingleOrDefaultAsync(where);
        }

        public async Task<int> Insert(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return 1;
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Added;
            }
            _dbcontext.SaveChanges();
            return entities.Count();
        }

        public int Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;
            _dbcontext.SaveChanges();
            return 1;
        }

        public int Update(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Modified;
            }
            _dbcontext.SaveChanges();
            return entities.Count();
        }

        public int Delete(TEntity entity)
        {
            if (_dbcontext.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
            _dbcontext.SaveChanges();
            return 1;
        }

        public async Task<int> Delete(object id)
        {
            TEntity? entityToDelete = await _entities.FindAsync(id);
            if (entityToDelete != null)
            {
                _entities.Remove(entityToDelete);
                _dbcontext.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Deleted;
            }
            _dbcontext.SaveChanges();
            return entities.Count();
        }

        #endregion IRepository<TEntity> Members

        #region SQL Queries

        // Execute query, return int
        public async Task<int> ExecuteSqlCommand(string query, params object[] parameters)
        {
            return await _dbcontext.Database.ExecuteSqlRawAsync(query, parameters);
        }

        #endregion SQL Queries
    }
}
