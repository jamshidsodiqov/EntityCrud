using Project.Domain.Commons;
using System.Linq.Expressions;

namespace Project.Data.IRepository
{
    public interface IGenericRepository<T> where T : Auditable
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true);
        ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true);
        ValueTask<T> CreateAsync(T entity);
        ValueTask<bool> DeleteAsync(int id);
        T UpdateAsync(T entity);
        ValueTask SaveChangesAsync();
    }
}
