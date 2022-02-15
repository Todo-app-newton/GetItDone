using AutoMapper;
using GetItDone_Models.DTO;
using GetItDone_Models.Enums;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetItDone_Backend.Controllers
{
    [ApiController]
    public class AssignmentController : ControllerBase
    {

        private readonly IAssignmentService _assingmentService;
        private readonly IMapper _autoMapper;
        private readonly IEmployeeService _employeeService;
        public AssignmentController(IMapper autoMapper, IAssignmentService assingmentService, IEmployeeService employeeService)
        {
            _autoMapper = autoMapper;
            _assingmentService = assingmentService;
            _employeeService = employeeService;
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
        [Route("api/Assignments/{email}")]
        public async Task<IActionResult> GetEmployeeAssignments(string email)
        {
            try
            {
                var employeesAssignments = await _employeeService.GetAllEmployeeAssignments(email);

                if (employeesAssignments is null) return NotFound();

                return Ok(_autoMapper.Map<List<AssignmentViewModel>>(employeesAssignments));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }
        [HttpPost]
        [Route("api/assignments/completeAssignment")]
        public async Task<IActionResult> CompleteAssignment(AssignmentsIdViewModel assignmentsIdViewModel)
        {
            try
            {
                var assignmentMapped = _autoMapper.Map<Assignment>(assignmentsIdViewModel);
                var assignment = await _assingmentService.GetAssignmentAsync(assignmentMapped.Id);
                var IsCompleted = await _assingmentService.CompleteAssignmnet(assignment);

                if (IsCompleted)
                    return Ok("Assignment successfully completed");
                else
                    return BadRequest("Assignment could not be completed, try again");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }
        [HttpPost]
        [Route("api/assignments/startAssignment")]
        public async Task<IActionResult> StartAssignment(AssignmentsIdViewModel assignmentsIdViewModel)
        {
            try
            {
                var assignmentMapped = _autoMapper.Map<Assignment>(assignmentsIdViewModel);
                var assignment = await _assingmentService.GetAssignmentAsync(assignmentMapped.Id);
                var IsCompleted = await _assingmentService.StartAssignmnet(assignment);

                if (IsCompleted)
                    return Ok("Assignment successfully completed");
                else
                    return BadRequest("Assignment could not be completed, try again");
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
        [Authorize("ProjectManager")]
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
        [Authorize("ProjectManager")]
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
        [Route("api/assignments")]
        public async Task<IActionResult> UpdateAssignment(AssignmentViewModelEdit assignmentViewModelEdit)
        {
            try
            {
               var assignmentMapped = _autoMapper.Map<Assignment>(assignmentViewModelEdit);
                var fetchAssignment = await _assingmentService.GetAssignmentAsync(assignmentMapped.Id);

                fetchAssignment.Title = assignmentViewModelEdit.Title;
                fetchAssignment.Description = assignmentViewModelEdit.Description;
                fetchAssignment.Period = assignmentViewModelEdit.Period;
                fetchAssignment.Progress = (Progress)Convert.ToInt32(assignmentViewModelEdit.Progress);

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