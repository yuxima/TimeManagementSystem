using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeManagementSystem.Data.Abstraction;
using TimeManagementSystem.Data.Entities;

namespace TimeManagementSystem.Data.Implementation.Repositories
{
    public class TaskItemRepository:Repository<TaskItem>, ITaskItemRepository
    {
        DbSet<TaskItem> _dbSet;
        public TaskItemRepository(ApplicationContext context):base(context)
        {
            _dbSet = context.Set<TaskItem>();
        }

        public new IQueryable<TaskItem> GetAllAsync(Expression<Func<TaskItem, bool>> filter)
        {
            IQueryable<TaskItem> entities = _dbSet;

            if (filter != null) entities = entities.Where(filter);

            return entities.Include(q => q.Project);
        }

        public new async Task<TaskItem> GetByIdAsync(string id)
        {
            return await _dbSet.Include(x=>x.Project).FirstOrDefaultAsync(x=>x.Id ==id);
        }
    }
}
