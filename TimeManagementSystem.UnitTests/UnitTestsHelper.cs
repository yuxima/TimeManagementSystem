using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeManagementSystem.BL.DTO;
using TimeManagementSystem.BL.Implementation;
using TimeManagementSystem.Data.Entities;
using TimeManagementSystem.Data.Implementation;

namespace TimeManagementSystem.UnitTests
{
    static class UnitTestsHelper
    {
        public static DbContextOptions<ApplicationContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationContext(options);
            FillWithData(context);
            return options;
        }

        public static Mapper CreateMapperProfile()
        {
            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }

        private static void FillWithData(ApplicationContext context)
        {
            context.Projects.Add(new Project { Id = "1", Name = "Project1", Abbr = "P1", Description = "This project about 1" , TaskItems = new List<TaskItem>(), Teams = new List<Team>()});
            context.Teams.Add(new Team
                { Id = "1", Name = "Team1", Users = new List<User>(), ProjectId = "1"});

            context.Users.Add(new User { Id = "1", Name = "Vasyl", Email = "vasyl@gmail.com" , TeamId = "1"});
            context.Users.Add(new User { Id = "2", Name = "Petro", Email = "petro@gmail.com" , TeamId = "1"});

            context.TaskItems.Add(new TaskItem
            {Id = "1", Name = "Task1", Description = "FirstReport", Date = new DateTime(2000, 11, 10), ProjectId = "1"});
            context.Reports.Add(new Report { Id = "1", Name = "Report1",  TaskItemId = "1", UserId = "1"});

            context.SaveChanges();
        }
    }
}
