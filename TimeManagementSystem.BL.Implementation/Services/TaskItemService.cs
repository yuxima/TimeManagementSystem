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
    public class TaskItemService : ITaskItemService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public TaskItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(TaskItemDto model)
        {
            var taskItem = _mapper.Map<TaskItem>(model);

            await _unitOfWork.TaskItemRepository.InsertAsync(taskItem);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            _unitOfWork.TaskItemRepository.DeleteByIdAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TaskItemDto>> GetAllAsync()
        {
            var taskItems = await _unitOfWork.TaskItemRepository.GetAllAsync().ToListAsync();

            return _mapper.Map<IEnumerable<TaskItemDto>>(taskItems);
        }

        public async Task<TaskItemDto> GetByIdAsync(string id)
        {
            var taskItem = await _unitOfWork.TaskItemRepository.GetByIdAsync(id);
            var taskItemDto = _mapper.Map<TaskItemDto>(taskItem);

            return taskItemDto;
        }

        public async Task UpdateAsync(TaskItemDto model)
        {
            var taskItem = _mapper.Map<TaskItem>(model);
            _unitOfWork.TaskItemRepository.Update(taskItem);

            await _unitOfWork.CommitAsync();
        }
    }
}
