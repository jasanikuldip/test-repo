using System;
using System.Collections.Generic;

namespace StudentPortal.Models.Data
{
    public partial class Teacher
    {
        public Teacher()
        {
            Studentmsts = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Contact { get; set; }

        public virtual ICollection<Student> Studentmsts { get; set; }
    }
}
