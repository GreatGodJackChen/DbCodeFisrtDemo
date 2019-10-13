using System;
using System.Collections.Generic;

namespace WebApplication2.DB
{
    public partial class Students
    {
        public Students()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int? GradeId { get; set; }

        public virtual Grades Grade { get; set; }
        public virtual StudentAddress StudentAddress { get; set; }
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
