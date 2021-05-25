﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeManagementSystem.Data.Abstraction;
using TimeManagementSystem.Data.Entities;

namespace TimeManagementSystem.Data.Implementation
{
    public static class DataServicesRegistrator
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository<Project>, Repository<Project>>();
            services.AddTransient<IRepository<Report>, Repository<Report>>();
            services.AddTransient<IRepository<TaskItem>, Repository<TaskItem>>();
            services.AddTransient<IRepository<Team>, Repository<Team>>();

            return services;
        }
    }
}
