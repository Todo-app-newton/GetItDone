using GetItDone_Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.DTO
{
    public class AssignmentDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Period { get; set; }
        public Progress Progress { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }
    }
}
