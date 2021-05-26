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
    public class ProjectService : IProjectService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(ProjectDto model)
        {
            var project = _mapper.Map<Project>(model);

            await _unitOfWork.ProjectRepository.InsertAsync(project);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            _unitOfWork.ProjectRepository.DeleteByIdAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _unitOfWork.ProjectRepository.GetAllAsync().ToListAsync();

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> GetByIdAsync(string id)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(id);
            var projectDto = _mapper.Map<ProjectDto>(project);

            return projectDto;
        }

        public async Task UpdateAsync(string id, ProjectDto model)
        {
            var project = _mapper.Map<Project>(model);
            _unitOfWork.ProjectRepository.Update(project);

            await _unitOfWork.CommitAsync();
        }
    }
}
