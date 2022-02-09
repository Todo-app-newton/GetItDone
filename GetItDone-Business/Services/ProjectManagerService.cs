using AutoMapper;
using GetItDone_Database.Repository;
using GetItDone_Models.DTO;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Business.Services
{
    public class ProjectManagerService : IProjectManagerService
    {
        private readonly GIDDatabaseRepository _databaseRepo;
        public ProjectManagerService(GIDDatabaseRepository databaseRepo, IMapper mapper)
        {
            _databaseRepo = databaseRepo;
        }

        public bool CreateProjectManager(ProjectManager createProjectManager)
        {
            try
            {
               return _databaseRepo.CreateProjectManager(createProjectManager).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<bool> DeleteProjectManagerAsync(int id)
        {
            try
            {
               var projectManager = await _databaseRepo.ProjectManagerAsync(id);

                if (projectManager is null) return false;

                return _databaseRepo.DeleteProjectManagerAsync(projectManager).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<ProjectManager> GetProjectManagerAsync(int id)
        {
            try
            {
                var projectManager = await _databaseRepo.ProjectManagerAsync(id);

                if (projectManager is null) return null;

                return projectManager;
                
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<IEnumerable<ProjectManager>> GetProjectManagersAsync()
        {
            try
            {
                var projectManagers = await _databaseRepo.ProjectManagersAsync();

                if (projectManagers.Any()) return projectManagers;

                return null;
            }
            catch (Exception)
            {
               //Implementing logger at later stage.
                throw;
            }
        }

        public bool UpdateProjectManagerAsync(ProjectManager updateProjectManager)
        {
            try
            {
  
                return _databaseRepo.UpdateProjectManagerAsync(updateProjectManager).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }
    }
}
