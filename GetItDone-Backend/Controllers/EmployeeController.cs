using AutoMapper;
using GetItDone_Business.Services;
using GetItDone_Models.DTO;
using GetItDone_Models.Interfaces.Services;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _autoMapper;
        public EmployeeController(IEmployeeService employeeService, IMapper autoMapper, IAssignmentService assignmentService)
        {
            _employeeService = employeeService;
            _autoMapper = autoMapper;
            _assignmentService = assignmentService;
        }


        [HttpGet]
        [Route("api/employees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployeesAsync();
                if (employees is null) return NotFound("No ProjectManagers could be found");

                return Ok(_autoMapper.Map<List<EmployeeViewModel>>(employees));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }


        [HttpGet]
        [Route("api/employee/Assignments/{email}")]
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

        [HttpGet]
        [Route("api/employee/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeAsync(id);

                if (employee is null) return NotFound("No employee could be found with that ID");

                return Ok(_autoMapper.Map<EmployeeViewModel>(employee));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPost]
        [Route("api/employee/completeAssignment")]
        public async Task<IActionResult> CompleteAssignment(int id)
        {
            try
            {
                var assignment = await _assignmentService.GetAssignmentAsync(id);
                var IsCompleted = await _assignmentService.CompleteAssignmnet(assignment);

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


        [HttpDelete]
        [Route("api/employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var isDeleted = await _employeeService.DeleteEmployeeAsync(id);

                if (isDeleted)
                    return NoContent();
                else
                    return BadRequest("Something happend when trying to delete employee, try again!");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPost]
        [Route("api/employee")]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = _autoMapper.Map<Employee>(employeeDTO);
                var IsCreated = _employeeService.CreateEmployeeAsync(employee);

                if (IsCreated)
                    return Ok("Successfully created employee");
                else
                    return BadRequest("Could not create the employee");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPut]
        [Route("api/employee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO employeeDto)
        {
            try
            {
                var fetchedEmployee = await _employeeService.GetEmployeeAsync(id);

                fetchedEmployee.FirstName = employeeDto.FirstName;
                fetchedEmployee.LastName = employeeDto.LastName;
                fetchedEmployee.Email = employeeDto.Email;
                fetchedEmployee.Profession = employeeDto.Profession;
                fetchedEmployee.CompanyId = employeeDto.CompanyId;

                var isUpdated = _employeeService.UpdateEmployeeAsync(fetchedEmployee);

                if (isUpdated)
                    return Ok("Employee is updated");
                else
                    return BadRequest("Unable to Update employee, Try again!");
            }
            catch (Exception)
            {
                //Logign implements later
                throw;
            }
        }
    }
}
