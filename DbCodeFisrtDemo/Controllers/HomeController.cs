using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DbCodeFisrtDemo.Data;
using Microsoft.AspNetCore.Mvc;
using DbCodeFisrtDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DbCodeFisrtDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly CodeFirstDbContext _dbContext;
        private readonly AddData _addData;
        public HomeController(CodeFirstDbContext dbContext, AddData addData)
        {
            _dbContext = dbContext;
            _addData = addData;
        }

        public IActionResult Index()
        {
            //using (var context = new EFCoreDBContext())
            //{ 
            //    var q= from a in context.User
            //           join from b in context.
            //}
                //var p= from o in _dbContext.User
                //       join from b in _dbContext.
                //Eager Loading（预加载）使用Include方法关联预先加载的实体。在这里就不举例说明了。
                //Explicit Loading（直接加载）使用Entry方法，对于集合使用Collection，单个实体则使用Reference。在这里就不举例说明了。
                //新增
                //_addData.Add();
                //_addData.AddOneTable();

                //一对多 做了延迟加载会自动加载子查询
                //var grade1 = _dbContext.Grades.Where(g => g.GradeId == 1);
                //var grade = _dbContext.Grades.Where(g => g.GradeId == 1).Where(g => g.Students.All(r => true)).ToList();
                //var grade2 = _dbContext.Grades;
                ////一对多 非延迟加载才用直接显示加载
                //var grade3 = _dbContext.Grades.FirstOrDefault(g => g.GradeId == 1);
                //if (grade3 != null)
                //{
                //    _dbContext.Entry(grade3).Collection(g => g.Students).Query().Load();
                //}
                //多对多
                var student = _dbContext.Students.Include(p => p.StudentCourses).ThenInclude(pt => pt.Course).ToList();

            //官方文档外键不为null 删除主从  外键为null 删除主表，从表外键为Null,测试结果为都是设置为见为null
            //所以先删除从后删除主表
            //删除 外键修改为null
            //var gra = _dbContext.Grades.Include(p=>p.Students).FirstOrDefault();
            //if (gra != null)
            //{
            //    var stu = gra.Students.ToList();
            //}
            //if (gra != null) _dbContext.Remove((object)gra);

            //
            var user = _dbContext.Users.Include(g=>g.Roles).FirstOrDefault();
            if (user != null)
            {
                var roles = user.Roles.ToList();
                _dbContext.Roles.RemoveRange(roles);
            }

            _dbContext.SaveChanges();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
