using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.BL.Implementation.Services
{
    public class TaskItemService : ITaskItemService
    {
        public Task AddAsync(TaskItemDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskItemDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TaskItemDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string id, TaskItemDto model)
        {
            throw new NotImplementedException();
        }
    }
}
