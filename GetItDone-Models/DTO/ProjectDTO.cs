using GetItDone_Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.DTO
{
   public class ProjectDTO
    {
        public Decimal Cost { get; set; }
        public DateTime Period { get; set; }
        public Progress Progress { get; set; }
        public int ProjectManagerId { get; set; }
        public int CustomerId { get; set; }
    }
}
