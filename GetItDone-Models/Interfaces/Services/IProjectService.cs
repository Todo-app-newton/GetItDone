using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Services
{
   public  interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<bool> CreateProjectAsync(Project project);
        Task<Project> GetProjectAsync(int id);
        Task<bool> DeleteProjectAsync(int id);
        bool UpdateProjectAsync(Project updateProject);
    }
}
