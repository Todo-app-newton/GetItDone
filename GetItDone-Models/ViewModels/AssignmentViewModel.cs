using GetItDone_Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.ViewModels
{
   public class AssignmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Period { get; set; }
        public string Progress { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }
    }
}
