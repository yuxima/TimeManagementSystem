using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.BL.Abstraction
{
    public interface ITaskItemService
    {
        Task AddAsync(TaskItemDto model);

        Task<TaskItemDto> GetByIdAsync(string id);

        Task<IEnumerable<TaskItemDto>> GetAllAsync();

        Task UpdateAsync(string id, TaskItemDto model);

        Task DeleteByIdAsync(string id);
    }
}
