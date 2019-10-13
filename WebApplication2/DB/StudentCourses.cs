using System;
using System.Collections.Generic;

namespace WebApplication2.DB
{
    public partial class StudentCourses
    {
        public int StudentCourseId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Students Student { get; set; }
    }
}
