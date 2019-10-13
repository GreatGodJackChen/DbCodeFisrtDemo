using System;
using System.Collections.Generic;

namespace WebApplication2.DB
{
    public partial class Courses
    {
        public Courses()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
