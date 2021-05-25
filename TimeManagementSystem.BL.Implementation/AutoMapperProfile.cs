using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeManagementSystem.BL.DTO;
using TimeManagementSystem.Data.Entities;

namespace TimeManagementSystem.BL.Implementation
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProjectDto, Project>().ReverseMap();

            CreateMap<ReportDto, Report>().ReverseMap();

            CreateMap<TaskItemDto, TaskItem>().ReverseMap();

            CreateMap<TeamDto, Team>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
