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
    public class AssignmentController : ControllerBase
    {

        private readonly AssignmentService _assingmentService;
        private readonly IMapper _autoMapper;
        public AssignmentController(IMapper autoMapper, AssignmentService assingmentService)
        {
            _autoMapper = autoMapper;
            _assingmentService = assingmentService;
        }


        [HttpGet]
        [Route("api/assignments")]
        public async Task<IActionResult> GetAssignments()
        {
            try
            {
                var assignments = await _assingmentService.GetAssignmentsAsync();

                if (assignments is null) return NotFound("No assignments could be found");

                return Ok(_autoMapper.Map<List<AssignmentViewModel>>(assignments));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpGet]
        [Route("api/assignment/{id}")]
        public async Task<IActionResult> GetAssignment(int id)
        {
            try
            {
                var assignment = await _assingmentService.GetAssignmentAsync(id);

                if (assignment is null) return NotFound("No Assignment could be found with that ID");

                return Ok(_autoMapper.Map<AssignmentViewModel>(assignment));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpDelete]
        [Route("api/assignment/{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            try
            {
                var isDeleted = await _assingmentService.DeleteAssignmentAsync(id);

                if (isDeleted)
                    return NoContent();
                else
                    return BadRequest("Something happend when trying to delete Assignment, try again!");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPost]
        [Route("api/assignment")]
        public IActionResult CreateAssignment([FromBody] AssignmentDTO assignmentDTO)
        {
            try
            {
                var assignment = _autoMapper.Map<Assignment>(assignmentDTO);
                var IsCreated = _assingmentService.CreateAssignmentAsync(assignment);

                if (IsCreated)
                    return Ok("Successfully created assignment");
                else
                    return BadRequest("Could not create the assignment");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPut]
        [Route("api/assignment/{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, AssignmentDTO assignmentDTO)
        {
            try
            {
                var fetchAssignment = await _assingmentService.GetAssignmentAsync(id);

                fetchAssignment.Title = assignmentDTO.Title;
                fetchAssignment.Description = assignmentDTO.Description;
                fetchAssignment.Period = assignmentDTO.Period;
                fetchAssignment.Progress = assignmentDTO.Progress;
                fetchAssignment.ProjectId = assignmentDTO.ProjectId;
                fetchAssignment.EmployeeId = assignmentDTO.EmployeeId;

                var isUpdated = _assingmentService.UpdateAssignmentAsync(fetchAssignment);

                if (isUpdated)
                    return Ok("Assignment is updated");
                else
                    return BadRequest("Unable to Update assignment, Try again!");
            }
            catch (Exception)
            {
                //Logign implements later
                throw;
            }
        }

    }
}
