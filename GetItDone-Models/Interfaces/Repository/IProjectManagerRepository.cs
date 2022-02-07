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
        Task DeleteProjectManagerAsync(int id);
        Task UpdateProjectManagerAsync(ProjectManager projectManager);
    }
}
