using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.BL.Abstraction
{
    public interface IReportService
    {
        Task AddAsync(ReportDto model);

        Task<ReportDto> GetByIdAsync(string id);

        Task<IEnumerable<ReportDto>> GetAllAsync();

        Task UpdateAsync(string id, ReportDto model);

        Task DeleteByIdAsync(string id);
    }
}
