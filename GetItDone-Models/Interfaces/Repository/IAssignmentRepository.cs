using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Repository
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> AssignmentsAsync();
        Task<Assignment> AssignmentAsync(int id);
        Task DeleteAssignmentAsync(int id);
        Task UpdateAssignmentAsync(Assignment assignment);
    }
}
