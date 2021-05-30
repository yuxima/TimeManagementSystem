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
    public class ReportService : IReportService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(ReportDto model)
        {
            var report = _mapper.Map<Report>(model);

            await _unitOfWork.ReportRepository.InsertAsync(report);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            _unitOfWork.ReportRepository.DeleteById(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            var reports = await _unitOfWork.ReportRepository.GetAllAsync().ToListAsync();

            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }

        public async Task<ReportDto> GetByIdAsync(string id)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(id);
            var reportDto = _mapper.Map<ReportDto>(report);

            return reportDto;
        }

        public async Task UpdateAsync(ReportDto model)
        {
            var report = _mapper.Map<Report>(model);
            _unitOfWork.ReportRepository.Update(report);

            await _unitOfWork.CommitAsync();
        }
    }
}
