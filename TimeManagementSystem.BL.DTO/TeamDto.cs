using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagementSystem.BL.DTO
{
    public class TeamDto
    {
        public string Name { get; set; }
        public string ProjectId { get; set; }
        public ProjectDto Project { get; set; }
    }
}
