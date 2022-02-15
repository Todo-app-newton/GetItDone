using AutoMapper;
using GetItDone_Models.DTO;
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
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IMapper _autoMapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _autoMapper = mapper;
        }

        [HttpGet]
        [Route("api/customers")]
        [Authorize("ProjectManager")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                var customer = await _customerService.GetCustomersAsync();

                if (customer is null) return NotFound("No ProjectManagers could be found");

                return Ok(_autoMapper.Map<List<CompanyViewModel>>(customer));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpGet]
        [Route("api/customer/{id}")]

        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerAsync(id);

                if (customer is null) return NotFound("No customer could be found with that ID");

                return Ok(_autoMapper.Map<CustomerViewModel>(customer));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpDelete]
        [Route("api/customer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var isDeleted = await _customerService.DeleteCustomerAsync(id);

                if (isDeleted)
                    return NoContent();
                else
                    return BadRequest("Something happend when trying to delete customer, try again!");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPost]
        [Route("api/customer")]
        [Authorize("ProjectManager")]
        public IActionResult CreateCustomer([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                var customer = _autoMapper.Map<Customer>(customerDTO);
                var IsCreated = _customerService.CreateCustomerAsync(customer);

                if (IsCreated)
                    return Ok("Successfully created customer");
                else
                    return BadRequest("Could not create the customer");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPut]
        [Route("api/customer/{id}")]
        [Authorize("ProjectManager")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            try
            {
                var fetchCustomer = await _customerService.GetCustomerAsync(id);

                fetchCustomer.FirstName = customerDTO.FirstName;
                fetchCustomer.LastName = customerDTO.LastName;
                fetchCustomer.Address = customerDTO.Address;
                fetchCustomer.PhoneNumber = customerDTO.PhoneNumber;
                fetchCustomer.PostalCode = customerDTO.PostalCode;


                var isUpdated = _customerService.UpdateCustomerAsync(fetchCustomer);

                if (isUpdated)
                    return Ok("Customer is updated");
                else
                    return BadRequest("Unable to Update customer, Try again!");
            }
            catch (Exception)
            {
                //Logign implements later
                throw;
            }
        }




    }
}
