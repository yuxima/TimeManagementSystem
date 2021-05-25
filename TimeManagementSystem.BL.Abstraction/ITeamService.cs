using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.BL.Abstraction
{
    public interface ITeamService
    {
        Task AddAsync(TeamDto model);

        Task<TeamDto> GetByIdAsync(string id);

        Task<IEnumerable<TeamDto>> GetAllAsync();

        Task UpdateAsync(string id, TeamDto model);

        Task DeleteByIdAsync(string id);
    }
}
