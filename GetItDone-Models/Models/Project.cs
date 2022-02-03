using GetItDone_Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GetItDone_Models.Models
{
   public class Project
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Decimal Cost { get; set; }
        public DateTime Period { get; set; }
        public Progress Progress { get; set; }

        public int ProjectManagerId { get; set; }
        public ProjectManager ProjectManager { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
