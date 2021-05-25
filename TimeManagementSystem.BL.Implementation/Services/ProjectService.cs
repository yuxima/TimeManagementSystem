using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;
using TimeManagementSystem.Data.Implementation;

namespace TimeManagementSystem.BL.Implementation.Services
{
    public class ProjectService : IProjectService
    {
        private ApplicationContext _context;
        private IMapper _mapper;

        public ProjectService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task AddAsync(ProjectDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _context.Projects.ToListAsync();

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public Task<ProjectDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string id, ProjectDto model)
        {
            throw new NotImplementedException();
        }
    }
}
