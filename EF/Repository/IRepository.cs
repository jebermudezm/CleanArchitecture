using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EF.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region IRepository<T> Members

       IQueryable<TEntity> AsQueryable();

       IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

       int? Max(Func<TEntity, int?> selector);

       int? Min(Func<TEntity, int?> selector);

       Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> First(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Last(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> Single(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<int> Insert(TEntity entity);

        int Insert(IEnumerable<TEntity> entities);

        int Update(TEntity entity);

        int Update(IEnumerable<TEntity> entities);

        int Delete(TEntity entity);

        Task<int> Delete(object id);

        int Delete(IEnumerable<TEntity> entities);

        #endregion IRepository<T> Members

        #region SQL Queries

        Task<int> ExecuteSqlCommand(string query, params object[] parameters);

        #endregion SQL Queries
    }
}
