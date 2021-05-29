using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeManagementSystem.Data.Entities;
using TimeManagementSystem.Data.Implementation;

namespace TimeManagementSystem.IntegrationTests
{
    public class TestWebAppFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<ApplicationContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryForceTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                using var scope = services.BuildServiceProvider().CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

                SeedData(context);
            });
        }

        private void SeedData(ApplicationContext context)
        {
            context.Projects.Add(new Project { Id = "1", Name = "Project1", Abbr = "P1", Description = "This project about 1", TaskItems = new List<TaskItem>(), Teams = new List<Team>() });
            context.Projects.Add(new Project { Id = "2", Name = "Project2", Abbr = "P2", Description = "This project about 2", TaskItems = new List<TaskItem>(), Teams = new List<Team>() });
            context.Teams.Add(new Team
                { Id = "1", Name = "Team1", Users = new List<User>(), ProjectId = "1" });

            context.Users.Add(new User { Id = "1", Name = "Vasyl", Email = "vasyl@gmail.com", TeamId = "1" });
            context.Users.Add(new User { Id = "2", Name = "Petro", Email = "petro@gmail.com", TeamId = "1" });

            context.TaskItems.Add(new TaskItem
                { Id = "1", Name = "Task1", Description = "FirstReport", Date = new DateTime(2000, 11, 10), ProjectId = "1" });
            context.Reports.Add(new Report { Id = "1", Name = "Report1", TaskItemId = "1", UserId = "1" });

            context.SaveChanges();
        }
    }
}
