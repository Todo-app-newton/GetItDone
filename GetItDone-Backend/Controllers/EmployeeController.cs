using AutoMapper;
using GetItDone_Models.DTO;
using GetItDone_Models.Enums;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GetItDone_Backend.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _autoMapper;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeeController(ICompanyService companyService, IEmployeeService employeeService, IMapper autoMapper, IAssignmentService assignmentService, UserManager<IdentityUser> userManager)
        {
            _companyService = companyService;
            _employeeService = employeeService;
            _autoMapper = autoMapper;
            _userManager = userManager;
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

        [HttpGet]
        [Route("api/employee/ByEmail/{email}")]
        public async Task<IActionResult> GetEmployeeWithEmail(string email)
        {
            try
            {
                var employees = await _employeeService.GetEmployeesAsync();

                var specificEmployee = employees.Where(x => x.Email == email).First();
                int compId = specificEmployee.CompanyId;
                if (specificEmployee is null) return NotFound("No employee could be found with that email");
                var company = await _companyService.GetCompanyAsync(compId);

                var employeeViewModel = _autoMapper.Map<EmployeeViewModel>(specificEmployee);

                var employee = new EmployeeDTO
                {
                    FirstName=specificEmployee.FirstName,
                    LastName=specificEmployee.LastName,
                    Email = specificEmployee.Email,
                    Profession= Enum.GetName(typeof(Profession), specificEmployee.Profession),
                    CompanyId= company.CompanyName
                };

                return Ok(employee);
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }


        [HttpDelete]
        [Route("api/employee/{id}")]
        [Authorize(Roles = "ProjectManager")]
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
        [Authorize(Roles = "ProjectManager")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = _autoMapper.Map<Employee>(employeeDTO);
                var IsCreated = await _employeeService.CreateEmployeeAsync(employee);

                var newEmployeeIdentityUser = new IdentityUser()
                {
                    UserName = employeeDTO.FirstName,
                    Email = employeeDTO.Email,
                };

                var employeeClaim = new Claim("Role", "Employeee");

               await _userManager.CreateAsync(newEmployeeIdentityUser, employeeDTO.Password);
               await _userManager.AddClaimAsync(newEmployeeIdentityUser, employeeClaim);

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
        [Authorize(Roles = "ProjectManager")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO employeeDto)
        {
            try
            {

                var employee = _autoMapper.Map<Employee>(employeeDto);
                var fetchedEmployee = await _employeeService.GetEmployeeAsync(employee.Id);
                

                fetchedEmployee.FirstName = employeeDto.FirstName;
                fetchedEmployee.LastName = employeeDto.LastName;
                fetchedEmployee.Email = employeeDto.Email;
                fetchedEmployee.Profession = (Profession)Convert.ToInt32(employeeDto.Profession);
                fetchedEmployee.CompanyId = employee.CompanyId;

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
