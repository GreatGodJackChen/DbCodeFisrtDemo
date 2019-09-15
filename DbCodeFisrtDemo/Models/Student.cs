using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DbCodeFisrtDemo.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public virtual StudentAddress Address { get; set; }

        public int Age { get; set; }
        //[ForeignKey("Grade")]
        //public int FGradeId { get; set; }

        //public int GradeId { get; set; }//如果改成 public int? GradeId则生成可空的外键
        public virtual Grade Grade { get; set; }

        //public virtual List<Course> Courses { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        //public  virtual  List<Student> StudentsP { get; set; }
        public virtual  List<StudentCourse> StudentCourses { get; set; }
    }
    [Table("StudentCourses")]
    public class StudentCourse
    {
        //public StudentCourse(int? studentId, int? courseId)
        //{
        //    if (studentId.HasValue)
        //        StudentId = studentId.Value;

        //    if (courseId.HasValue)
        //        CourseId = courseId.Value;
        //}
        [Key]
        public int StudentCourseId { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
    [Table("Grades")]
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public virtual List<Student> Students { get; set; }
    }
    [Table("StudentAddress")]
    public class StudentAddress
    {
        [Key]
        public int StudentAddressId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Student Student { get; set; }
    }
}
