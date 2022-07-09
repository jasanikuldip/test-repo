using System;
using System.Collections.Generic;

namespace StudentPortal.Models.Data
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public string? Lastname { get; set; }
        public string? Rollno { get; set; }
        public int? Standard { get; set; }
        public int? Reporting { get; set; }

        public virtual Teacher? ReportingNavigation { get; set; }
    }
}
