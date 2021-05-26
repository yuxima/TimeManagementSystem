using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;
using TimeManagementSystem.Controllers;

namespace TimeManagementSystem.UnitTests.ControllerTests
{
    [TestFixture]
    class ProjectControllerTests
    {
        private Mock<IProjectService> _projectService;
        private ProjectController _projectController;
        private ProjectDto project;

        [SetUp]
        public void SetUp()
        {
            _projectService = new Mock<IProjectService>();
            _projectController = new ProjectController(_projectService.Object);

            project = new ProjectDto() {Id = "1", Name = "ProjectName"};
        }

        [Test]
        public void GetAll_ReturnsAllSubjects()
        {
            //Arrange
            _projectService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<ProjectDto>());

            //Act
            var actionResult = _projectController.Index();


            //Assert 
            actionResult.Result.Should().BeOfType<ActionResult<IEnumerable<ProjectDto>>>();
        }

        [Test]
        public void GetById_ReturnsSubject()
        {
            //Arrange
            _projectService.Setup(s => s.GetByIdAsync("1")).ReturnsAsync(new ProjectDto {Id = "1"});

            //Act
            var actionResult = _projectController.("1");

            //Assert
            actionResult.Result.Should().BeOfType<ActionResult<SubjectDTO>>();
        }

        [Test]
        public void Add_ModelIsValid_ReturnsCreatedAtAction()
        {
            //Arrange
            _subjectService.Setup(s => s.AddAsync(project));

            //Act
            var actionResult = _subjectController.Add(project).Result as CreatedAtActionResult;

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.StatusCode.Should().Be(201);
        }

        [Test]
        public void Add_ModelIsInvalid_ReturnsBadRequest()
        {
            //Arrange
            _subjectService.Setup(s => s.AddAsync(project)).ThrowsAsync(new Exception());

            //Act
            var actionResult = _subjectController.Add(project).Result as BadRequestObjectResult;

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.StatusCode.Should().Be(400);
        }

        [Test]
        public void Update_ModelIsValid_ReturnsOK()
        {
            //Arrange
            _subjectService.Setup(s => s.UpdateAsync(project));

            //Act
            var actionResult = _subjectController.Update(project).Result as OkResult;

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.StatusCode.Should().Be(200);
        }

        [Test]
        public void Update_ModelIsNotValid_ReturnsBadRequest()
        {
            //Arrange
            _subjectService.Setup(s => s.UpdateAsync(project));

            //Act
            var actionResult = _subjectController.Update(null).Result as BadRequestResult;

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.StatusCode.Should().Be(400);
        }

        [Test]
        public void Delete_ReturnsOk()
        {
            //Arrange
            _subjectService.Setup(s => s.DeleteByIdAsync(project.Id));

            //Act
            var actionResult = _subjectController.Delete(project.Id).Result as OkResult;

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.StatusCode.Equals(200);
        }
    }
}
