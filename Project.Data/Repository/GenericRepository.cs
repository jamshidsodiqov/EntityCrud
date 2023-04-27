using Microsoft.EntityFrameworkCore;
using Project.Data.DbContexts;
using Project.Data.IRepository;
using Project.Domain.Commons;
using System.Linq.Expressions;

namespace Project.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        private readonly AppDbContext dbContext;
        private DbSet<T> dbSet;

        public GenericRepository()
        {
            this.dbContext = new AppDbContext();
            this.dbSet = dbContext.Set<T>();
        }

        public async ValueTask<T> CreateAsync(T entity)
            => (await dbContext.AddAsync(entity)).Entity;

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var deletedEntity = await GetAsync(u => u.Id == id);

            if (deletedEntity == null)
                return false;

            dbSet.Remove(deletedEntity);

            return true;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
        {
            var entity = dbSet.Where(expression);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    if (!string.IsNullOrEmpty(include))
                        dbSet.Include(include);
                }
            }
            if (!isTracking)
            {
                dbSet.AsNoTracking();
            }
            return entity;
        }

        public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
            => await GetAll(expression, includes, false).FirstOrDefaultAsync();

        public T UpdateAsync(T entity)
            => dbSet.Update(entity).Entity;

        public async ValueTask SaveChangesAsync() =>
        await dbContext.SaveChangesAsync();
    }
}
