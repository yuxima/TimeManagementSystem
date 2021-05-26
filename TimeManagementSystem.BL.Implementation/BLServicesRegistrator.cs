using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.Implementation.Services;

namespace TimeManagementSystem.BL.Implementation
{
    public static class BLServicesRegistrator
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new AutoMapperProfile()));
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<ITaskItemService, TaskItemService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
