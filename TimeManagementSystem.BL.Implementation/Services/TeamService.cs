using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;
using TimeManagementSystem.Data.Abstraction;
using TimeManagementSystem.Data.Entities;

namespace TimeManagementSystem.BL.Implementation.Services
{
    public class TeamService : ITeamService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(TeamDto model)
        {
            var team = _mapper.Map<Team>(model);

            await _unitOfWork.TeamRepository.InsertAsync(team);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            _unitOfWork.TeamRepository.DeleteByIdAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            var teams = await _unitOfWork.TeamRepository.GetAllAsync().ToListAsync();

            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }

        public async Task<TeamDto> GetByIdAsync(string id)
        {
            var team = await _unitOfWork.TeamRepository.GetByIdAsync(id);
            var teamDto = _mapper.Map<TeamDto>(team);

            return teamDto;
        }

        public async Task UpdateAsync(TeamDto model)
        {
            var team = _mapper.Map<Team>(model);
            _unitOfWork.TeamRepository.Update(team);

            await _unitOfWork.CommitAsync();
        }
    }
}
