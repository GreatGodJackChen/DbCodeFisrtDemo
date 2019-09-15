using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbCodeFisrtDemo.Models;

namespace DbCodeFisrtDemo.Data
{
    public class AddData
    {
        private readonly CodeFirstDbContext _dbContext;
        public  AddData(CodeFirstDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //1.左右侧都为新增
        public  void Add()
        {
            var studentCourse=new StudentCourse()
            {
                Student = new Student()
                {
                    StudentName = "小明",Age = 18
                },
                Course = new Course()
                {
                    CourseName = "语文"
                }
            };
            _dbContext.StudentCourses.Add(studentCourse);
            _dbContext.SaveChanges();
            //左右侧表建立关联关系
            //students.ForEach(a=>course.StudentCourses.AddRange());
        }

        public void AddOneTable()
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.StudentName.Contains("小明"));
            var studentCourse = new StudentCourse()
            {
                Student = student,
                Course = new Course()
                {
                    CourseName = "数学"
                }
            };
            _dbContext.AddRange(studentCourse);
            _dbContext.SaveChanges();
        }
    }
}
