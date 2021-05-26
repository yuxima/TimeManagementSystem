using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimeManagementSystem.Data.Entities;

namespace TimeManagementSystem.Data.Abstraction
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByIdAsync(string id);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        void DeleteByIdAsync(string id);
    }
}
