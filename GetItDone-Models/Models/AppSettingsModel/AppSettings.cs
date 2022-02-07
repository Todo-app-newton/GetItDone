using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.Models
{
    public static class AppSettings
    {
        public static string HostName { get; set; }
        public static string SecretKey { get; set; }
        public static string ProjectManagerPassword { get; set; }
        public static string EmployeePassword { get; set; }
        public static string CompanyPassword { get; set; }
    }
}
