using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.DB
{
    public partial class EFCoreDBContext : DbContext
    {
        public EFCoreDBContext()
        {
        }

        public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Com> Com { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<Mid> Mid { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<StudentAddress> StudentAddress { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCoreDB;User ID=sa;Password=sa_112212;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Com>(entity =>
            {
                entity.ToTable("com");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ComName)
                    .HasColumnName("comName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId);
            });

            modelBuilder.Entity<Grades>(entity =>
            {
                entity.HasKey(e => e.GradeId);
            });

            modelBuilder.Entity<Mid>(entity =>
            {
                entity.ToTable("mid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ComId).HasColumnName("comId");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdP);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<StudentAddress>(entity =>
            {
                entity.HasIndex(e => e.StudentId)
                    .IsUnique();

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.StudentAddress)
                    .HasForeignKey<StudentAddress>(d => d.StudentId);
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasKey(e => e.StudentCourseId);

                entity.HasIndex(e => e.CourseId);

                entity.HasIndex(e => e.StudentId);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.HasIndex(e => e.GradeId);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });
        }
    }
}
