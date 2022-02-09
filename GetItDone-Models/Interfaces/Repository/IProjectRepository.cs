using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Repository
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ProjectsAsync();
        Task<Project> ProjectAsync(int id);
        Task CreateProject(Project project);
        Task DeleteProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
    }
}
