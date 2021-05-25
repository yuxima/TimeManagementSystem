using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.Implementation.Services;

namespace TimeManagementSystem.BL.Implementation
{
    public static class BLServicesRegistrator
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            

            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<ITaskItemService, TaskItemService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
