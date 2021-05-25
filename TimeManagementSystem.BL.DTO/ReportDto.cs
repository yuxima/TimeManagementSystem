using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagementSystem.BL.DTO
{
    public class ReportDto
    {
        public string Name { get; set; }
        public string TaskItemId { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
        public TaskItemDto TaskItem { get; set; }
    }
}
