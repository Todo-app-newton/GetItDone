using GetItDone_Database.Repository;
using GetItDone_Models.DTO;
using GetItDone_Models.Enums;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Business.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly GIDDatabaseRepository _databaseRepo;
        public AssignmentService(GIDDatabaseRepository databaseRepo)
        {
            _databaseRepo = databaseRepo;
        }

        public bool CreateAssignmentAsync(Assignment createAssignment)
        {
            try
            {
                var projectId = _databaseRepo.ProjectAsync(createAssignment.ProjectId);
                var employeeId = _databaseRepo.EmployeeAsync(createAssignment.EmployeeId);

                var newAssignment = new Assignment
                {
                    Title = createAssignment.Title,
                    Description = createAssignment.Description,
                    Period = createAssignment.Period,
                    Progress = createAssignment.Progress,
                    ProjectId = projectId.Id,
                    EmployeeId = projectId.Id
                };


                return _databaseRepo.CreateAssignmenAsync(newAssignment).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }
        public async Task<bool> CompleteAssignmnet(Assignment assignment)
        {
            try
            {

                var completeAssignment = new Assignment
                {
                    Id = assignment.Id,
                    Title = assignment.Title,
                    Description = "fuck u",
                    Period = assignment.Period,
                    Progress = Progress.Completed,
                    EmployeeId = assignment.EmployeeId,
                    ProjectId = assignment.ProjectId
                };

                await _databaseRepo.UpdateAssignmentAsync(completeAssignment);

                return true;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            try
            {
                var assignment = await _databaseRepo.AssignmentAsync(id);

                if (assignment is null) return false;

                return _databaseRepo.DeleteAssignmentAsync(assignment).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<Assignment> GetAssignmentAsync(int id)
        {
            try
            {
                var assignment = await _databaseRepo.AssignmentAsync(id);

                if (assignment is null) return null;

                return assignment;

            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync()
        {
            try
            {
                var assignments = await _databaseRepo.AssignmentsAsync();

                if (assignments.Any()) return assignments;

                return null;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public bool UpdateAssignmentAsync(Assignment updateAssignment)
        {
            try
            {
                return _databaseRepo.UpdateAssignmentAsync(updateAssignment).IsCompletedSuccessfully;
            }
            catch (Exception ex)
            {
                //Implementing logger at later stage.
                throw ex;
            }
        }

        public async Task<bool> StartAssignmnet(Assignment assignment)
        {
            try
            {

                var completeAssignment = new Assignment
                {
                    Id = assignment.Id,
                    Title = assignment.Title,
                    Description = "fuck u",
                    Period = assignment.Period,
                    Progress = Progress.Started,
                    EmployeeId = assignment.EmployeeId,
                    ProjectId = assignment.ProjectId
                };

                await _databaseRepo.UpdateAssignmentAsync(completeAssignment);

                return true;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }
    }
}
