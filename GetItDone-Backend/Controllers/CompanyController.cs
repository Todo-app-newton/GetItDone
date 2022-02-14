using AutoMapper;
using GetItDone_Models.DTO;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetItDone_Backend.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _autoMapper;
        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _autoMapper = mapper;
        }

        [HttpGet]
        [Route("api/companies")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyService.GetCompanysAsync();

                if (companies is null) return NotFound("No Company could be found");

                return Ok(_autoMapper.Map<List<CompanyViewModel>>(companies));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpGet]
        [Route("api/company/{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _companyService.GetCompanyAsync(id);

                if (company is null) return NotFound("No Company could be found with that ID");

                return Ok(_autoMapper.Map<CompanyViewModel>(company));
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpDelete]
        [Route("api/company/{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var isDeleted = await _companyService.DeleteCompanyAsync(id);

                if (isDeleted)
                    return NoContent();
                else
                    return BadRequest("Something happend when trying to delete Company, try again!");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPost]
        [Route("api/company")]
        public IActionResult CreateCompany([FromBody] CompanyDTO companDTO)
        {
            try
            {
                var company = _autoMapper.Map<Company>(companDTO);
                var IsCreated = _companyService.CreateCompanyAsync(company);

                if (IsCreated)
                    return Ok("Successfully created Company");
                else
                    return BadRequest("Could not create the Company");
            }
            catch (Exception)
            {
                //Logging implments later
                throw;
            }
        }

        [HttpPut]
        [Route("api/company/{id}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyDTO companyDTO)
        {
            try
            {
                var fetchCompany = await _companyService.GetCompanyAsync(id);

                fetchCompany.CompanyName = companyDTO.CompanyName;


                var isUpdated = _companyService.UpdateCompanyAsync(fetchCompany);

                if (isUpdated)
                    return Ok("Company is updated");
                else
                    return BadRequest("Unable to Update Company, Try again!");
            }
            catch (Exception)
            {
                //Logign implements later
                throw;
            }
        }

    }
}
