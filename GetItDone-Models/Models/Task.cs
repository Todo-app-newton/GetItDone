using GetItDone_Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Period { get; set; }
        public Progress Progress { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
