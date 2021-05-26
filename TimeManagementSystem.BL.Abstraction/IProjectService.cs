using System.Collections.Generic;
using System.Threading.Tasks;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.BL.Abstraction
{
    public interface IProjectService
    {
        Task AddAsync(ProjectDto model);

        Task<ProjectDto> GetByIdAsync(string id);

        Task<IEnumerable<ProjectDto>> GetAllAsync();

        Task UpdateAsync(ProjectDto model);

        Task DeleteByIdAsync(string id);
    }
}
