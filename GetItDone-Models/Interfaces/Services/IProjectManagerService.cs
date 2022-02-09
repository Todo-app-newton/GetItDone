using GetItDone_Models.DTO;
using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Services
{
    public interface IProjectManagerService
    {
        Task<IEnumerable<ProjectManager>> GetProjectManagersAsync();
        bool CreateProjectManager(ProjectManager createProjectManager);
        Task<ProjectManager> GetProjectManagerAsync(int id);
        Task<bool> DeleteProjectManagerAsync(int id);
        bool UpdateProjectManagerAsync(ProjectManager updateProjectManager);
    }
}
