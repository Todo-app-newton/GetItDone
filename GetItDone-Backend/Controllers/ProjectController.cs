using AutoMapper;
using GetItDone_Business.Services;
using GetItDone_Models.DTO;
using GetItDone_Models.Models;
using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetItDone_Backend.Controllers
{
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly ProjectService _projectService;
        private readonly IMapper _autoMapper;
        public ProjectController(ProjectService projectService, IMapper autoMapper)
        {
            _projectService = projectService;
            _autoMapper = autoMapper;
        }


        [HttpGet]
        [Route("api/projects")]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                var projects = await _projectService.GetProjectsAsync();

                if (projects is null) return NotFound("No ProjectManagers could be found");

                return Ok(_autoMapper.Map<List<ProjectViewModel>>(projects));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpGet]
        [Route("api/project/{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            try
            {
                var project = await _projectService.GetProjectAsync(id);

                if (project is null) return NotFound("No project could be found with that ID");

                return Ok(_autoMapper.Map<ProjectViewModel>(project));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpDelete]
        [Route("api/project/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                var isDeleted = await _projectService.DeleteProjectAsync(id);

                if (isDeleted)
                    return NoContent();
                else
                    return BadRequest("Something happend when trying to delete project, try again!");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPost]
        [Route("api/project")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDTO projectDTO)
        {
            try
            {
                var project = _autoMapper.Map<Project>(projectDTO);
                var IsCreated = await _projectService.CreateProjectAsync(project);

                if (IsCreated)
                    return Ok("Successfully created project");
                else
                    return BadRequest("Could not create the project");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPut]
        [Route("api/project/{id}")]
        public async Task<IActionResult> UpdateProject(int id, ProjectDTO projectDTO)
        {
            try
            {
                var fetchProject = await _projectService.GetProjectAsync(id);

                fetchProject.Cost = projectDTO.Cost;
                fetchProject.Period = projectDTO.Period;
                fetchProject.Progress = projectDTO.Progress;
                fetchProject.ProjectManagerId = projectDTO.ProjectManagerId;
                fetchProject.CustomerId = projectDTO.CustomerId;


                var isUpdated = _projectService.UpdateProjectAsync(fetchProject);

                if (isUpdated)
                    return Ok("project is updated");
                else
                    return BadRequest("Unable to Update project, Try again!");
            }
            catch (Exception)
            {
                //Logign implements later
                throw;
            }
        }



    }
}
