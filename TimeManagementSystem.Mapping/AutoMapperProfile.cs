using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeManagementSystem.BL.DTO;
using TimeManagementSystem.Data.Entities;
using TimeManagementSystem.Models;

namespace TimeManagementSystem.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProjectDto, Project>().ReverseMap();
            CreateMap<ProjectDto, ProjectViewModel>().ReverseMap();

            CreateMap<ReportDto, Report>().ReverseMap();

            CreateMap<TaskItemDto, TaskItem>().ReverseMap();

            CreateMap<TeamDto, Team>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
