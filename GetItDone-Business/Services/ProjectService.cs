using GetItDone_Database.Repository;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly GIDDatabaseRepository _databaseRepo;
        public ProjectService(GIDDatabaseRepository databaseRepo)
        {
            _databaseRepo = databaseRepo;
        }
        public async Task<bool> CreateProjectAsync(Project project)
        {
            try
            {
                var projectManager = await _databaseRepo.ProjectManagerAsync(project.ProjectManagerId);
                var customer = await _databaseRepo.CustomerAsync(project.CustomerId);

                var newProject = new Project
                {
                    Cost = project.Cost,
                    CustomerId = customer.Id,
                    Period = project.Period,
                    Progress = project.Progress,
                    ProjectManagerId = projectManager.Id
                };

               return _databaseRepo.CreateProject(newProject).IsCompletedSuccessfully;
            }
            catch (Exception)
            {   
                //Logging will be implemented later.
                throw;
            }
          

        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            try
            {
                var project = await _databaseRepo.ProjectAsync(id);

                if (project is null) return false;

                return _databaseRepo.DeleteProjectAsync(project).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            try
            {
                var project = await _databaseRepo.ProjectAsync(id);

                if (project is null) return null;

                return project;

            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            try
            {
                var projects = await _databaseRepo.ProjectsAsync();

                if (projects.Any()) return projects;

                return null;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public bool UpdateProjectAsync(Project updateProject)
        {
            try
            {
                return _databaseRepo.UpdateProjectAsync(updateProject).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }
    }
}
