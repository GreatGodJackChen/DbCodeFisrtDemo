using DbCodeFisrtDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCodeFisrtDemo.Data
{
    public class CodeFirstDBContext:DbContext
    {
        public CodeFirstDBContext(DbContextOptions<CodeFirstDBContext> options)
            : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
    }
}
