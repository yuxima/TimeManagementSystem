using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.BL.Implementation.Services
{
    public class TeamService : ITeamService
    {
        public Task AddAsync(TeamDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeamDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string id, TeamDto model)
        {
            throw new NotImplementedException();
        }
    }
}
