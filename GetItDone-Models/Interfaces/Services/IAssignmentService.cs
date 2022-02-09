using GetItDone_Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Services
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> GetAssignmentsAsync();
        bool CreateAssignmentAsync(Assignment createAssignment);
        Task<Assignment> GetAssignmentAsync(int id);
        Task<bool> DeleteAssignmentAsync(int id);
        bool UpdateAssignmentAsync(Assignment updateAssignment);
    }
}
