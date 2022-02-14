using AutoMapper;
using FluentAssertions;
using GetItDone_Backend.Controllers;
using GetItDone_Business.Services;
using GetItDone_Models.AutoMapper;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Testing.Backend_Controllers
{
    [TestClass]
    public class ProjectManagerControllerTest
    {
        private readonly Mock<IProjectManagerService> _mockService;
        private readonly ProjectManagerController projectManagerController;
        private readonly IMapper _mapper;
        public ProjectManagerControllerTest()
        {
            if(_mapper is null)
            {
                var myProfile = new AutoMapperProfile();
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(myProfile);
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _mockService = new Mock<IProjectManagerService>();
            projectManagerController = new ProjectManagerController(_mockService.Object, _mapper);
        }


        private List<ProjectManager> projectManagers = null;

        [TestMethod]
        public async Task GetAllProjectManagers_ShouldReturnNotFound_WhenListIsEmpty()
        {
            //Arrange
            _mockService.Setup(x => x.GetProjectManagersAsync()).ReturnsAsync(projectManagers);
            //Act
            var response = await projectManagerController.GetProjectManagers();

            //Assert           
            response.Should().BeOfType<NotFoundObjectResult>();
        }

        [TestMethod]
        public async Task GetProjectManager_ShouldReturnNotFound_WhenProjectManagerNotExist()
        {
            //Arrange
            var idNumber = 11;
            ProjectManager nullValue = null;
            _mockService.Setup(x => x.GetProjectManagerAsync(It.IsAny<int>())).ReturnsAsync(nullValue);
            //Act
            var response = await projectManagerController.GetProjectManager(idNumber);
            //Assert
            var result = response.Should().BeOfType<NotFoundObjectResult>().Subject;
            result.Value.Should().Be("No projectManager could be found with that ID");
        }

        [TestMethod]
        public async Task GetProjectManager_ShouldReturnOk_WhenProjectManagerExists()
        {
            //Arrange
            var idNumber = 1;
            _mockService.Setup(x => x.GetProjectManagerAsync(It.IsAny<int>())).ReturnsAsync(new ProjectManager { Id = 1, FirstName = "John", LastName = "Johnsson", PhoneNumber = "112" });
            //Act
            var response = await projectManagerController.GetProjectManager(idNumber);
            //Assert
            var result = response.Should().BeOfType<OkObjectResult>().Subject;
            var okValue = result.Value.Should().BeOfType<ProjectManagerViewModel>().Subject;
            okValue.FirstName.Should().Be("John");
        }

        [TestMethod]
        public async Task DeleteProjectManager_ShouldReturnBadRequest_WhenProjectManagerCouldntBeDeleted()
        {
            //Arrange
            _mockService.Setup(x => x.DeleteProjectManagerAsync(It.IsAny<int>())).ReturnsAsync(false);
            //Act
            var response = await projectManagerController.DeleteProjectManager(1);
            //Assert
            var result = response.Should().BeOfType<BadRequestObjectResult>().Subject;
            result.Value.Should().Be("Something happend when trying to delete projectManager, try again!");
        }


    }
}
