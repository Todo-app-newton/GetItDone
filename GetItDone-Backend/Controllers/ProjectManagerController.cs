using AutoMapper;
using GetItDone_Business.Services;
using GetItDone_Models.DTO;
using GetItDone_Models.Models;
using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Backend.Controllers
{

    [ApiController]
    public class ProjectManagerController : ControllerBase
    {
        private readonly ProjectManagerService _projectManagerService;
        private readonly IMapper _autoMapper;
        public ProjectManagerController(ProjectManagerService projectManagerService, IMapper autoMapper)
        {
            _projectManagerService = projectManagerService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("api/projectmanagers")]
        public async Task<IActionResult> GetProjectManagers()
        {
            try
            {
                var projectManagers = await _projectManagerService.GetProjectManagersAsync();

                if (projectManagers is null) return NotFound("No ProjectManagers could be found");

                return Ok(_autoMapper.Map<List<ProjectManagerViewModel>>(projectManagers));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpGet]
        [Route("api/projectmanager/{id}")]
        public async Task<IActionResult> GetProjectManager(int id)
        {
            try
            {
                var projectManager = await _projectManagerService.GetProjectManagerAsync(id);

                if (projectManager is null) return NotFound("No projectManager could be found with that ID");

                return Ok(_autoMapper.Map<ProjectManagerViewModel>(projectManager));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpDelete]
        [Route("api/projectManager/{id}")]
        public async Task<IActionResult> DeleteProjectManager(int id)
        {
            try
            {
                var isDeleted = await _projectManagerService.DeleteProjectManagerAsync(id);

                if (isDeleted)
                    return NoContent();
                else
                    return BadRequest("Something happend when trying to delete projectManager, try again!");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPost]
        [Route("api/projectManager")]
        public IActionResult CreateProjectManager([FromBody] ProjectManagerDTO projectManagerDTO)
        {
            try
            {
                var projectManager = _autoMapper.Map<ProjectManager>(projectManagerDTO);
                var IsCreated = _projectManagerService.CreateProjectManager(projectManager);

                if (IsCreated)
                    return Ok("Successfully created ProjectManager");
                else 
                    return BadRequest("Could not create the projectManager");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPut]
        [Route("api/projectManager/{id}")]
        public async Task<IActionResult> UpdateProjectManager(int id, ProjectManagerDTO projectManagerDTO)
        {
            try
            {
                var fetchProjectManager = await _projectManagerService.GetProjectManagerAsync(id);

                fetchProjectManager.FirstName = projectManagerDTO.FirstName;
                fetchProjectManager.LastName = projectManagerDTO.LastName;
                fetchProjectManager.PhoneNumber = projectManagerDTO.PhoneNumber;

                var isUpdated = _projectManagerService.UpdateProjectManagerAsync(fetchProjectManager);

                if (isUpdated)
                    return Ok("Project Manager is updated");
                else
                    return BadRequest("Unable to Update Project Manager, Try again!");
            }
            catch (Exception)
            {
                //Logign implements later
                throw;
            }
        }
    }
}
