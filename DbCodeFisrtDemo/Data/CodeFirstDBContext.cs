using DbCodeFisrtDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace DbCodeFisrtDemo.Data
{
    public class CodeFirstDbContext : DbContext
    {
        //1.启用迁移功能：Enable-Migrations -ContextTypeName MvcMovie.Models.MovieDbContext
        //2.建立初态：add-migration Initial
        //3.自动比对差异生成迁移类：add-migration AddRatingMig
        //4.将迁移应用到数据库：update-database

        //依次执行 Enable-Migrations
        //Add-Migration 1 (1是随便写的)
        //DbLoggerCategory.Update-Database
        public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options)
            : base(options)
        {
        }
        //public DbSet<User> User { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresss { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
