using GetItDone_Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Profession Profession { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
