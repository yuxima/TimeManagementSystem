using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.BL.Implementation.Services
{
    public class ReportService : IReportService
    {
        public Task AddAsync(ReportDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReportDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string id, ReportDto model)
        {
            throw new NotImplementedException();
        }
    }
}
