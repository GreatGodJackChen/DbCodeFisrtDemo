using System;
using System.Collections.Generic;

namespace WebApplication2.DB
{
    public partial class Grades
    {
        public Grades()
        {
            Students = new HashSet<Students>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
