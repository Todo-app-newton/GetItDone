using AutoMapper;
using GetItDone_Models.DTO;
using GetItDone_Models.Models;
using GetItDone_Models.ViewModels;

namespace GetItDone_Models.AutoMapper
{
     public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            //  Source -> Destination

            //Incoming from frontend 
            CreateMap<ProjectManagerDTO, ProjectManager>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<CompanyDTO, Company>();
            CreateMap<ProjectDTO, Project>();

            //Outgoint to frontend
            CreateMap<ProjectManager, ProjectManagerViewModel>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
        }
    }
}
