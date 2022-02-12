using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Repository
{
    public interface IProjectManagerRepository
    {
        Task<IEnumerable<ProjectManager>> ProjectManagersAsync();
        Task<ProjectManager> ProjectManagerAsync(int id);
        Task CreateProjectManager(ProjectManager projectManager);
        Task DeleteProjectManagerAsync(ProjectManager projectManager);
        Task UpdateProjectManagerAsync(ProjectManager projectManager);
    }
}
