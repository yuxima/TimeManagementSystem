using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimeManagementSystem.Data.Abstraction;
using TimeManagementSystem.Data.Entities;

namespace TimeManagementSystem.Data.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        ApplicationContext _context;
        DbSet<TEntity> _dbSet;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async void DeleteByIdAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> entities = _dbSet;

            if (filter != null) entities = entities.Where(filter);

            return entities;
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
