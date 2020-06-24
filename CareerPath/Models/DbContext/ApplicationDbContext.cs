using System;
using System.Collections.Generic;
using System.Text;
using CareerPath.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CareerPath.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyUser, MyRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exams>()
                .HasKey(ww => ww.ExamId);

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<QuestionExam>()
                .HasKey(ww => new { ww.ExamId, ww.QuestId });

            modelBuilder.Entity<Career>()
                .HasKey(ww => ww.CareerId);

            modelBuilder.Entity<SubCareer>()
                .HasKey(ww => new { ww.SubCareerId });

            modelBuilder.Entity<Course>()
                .HasKey(ww => ww.CourseId);

            modelBuilder.Entity<SubCareerCourse>()
                .HasKey(ww => new { ww.CourseId, ww.SubCareerId });

            modelBuilder.Entity<UserExam>()
             .HasKey(ww => new { ww.UserId, ww.ExamId });


            modelBuilder.Entity<Slider>()
                .HasKey(ww => ww.SliderID);

            //modelBuilder.Entity<User>()
            //        .HasKey(ww => new { ww.UserId });

            modelBuilder.Entity<UserCourse>()
                .HasKey(ww => new { ww.UserId, ww.CourseId , ww.StartDate });

            modelBuilder.Entity<Questions>()
                .HasKey(ww => ww.QuestId);

            modelBuilder.Entity<Status>()
                .HasKey(ww => ww.StatusId);

            modelBuilder.Entity<UserGrade>()
                .HasKey(ww => ww.GradeOfUser);

           

        }

        public virtual DbSet<Career> Career { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<QuestionExam> QuestExam { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<SubCareer> SubCareer { get; set; }
        public virtual DbSet<SubCareerCourse> SubCareerCourse { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<UserCourse> UserCourse { get; set; }
        public virtual DbSet<UserExam> UserExam { get; set; }
        public virtual DbSet<UserGrade> UserGrades { get; set; }
        public virtual DbSet<CoursePath> CoursePaths { get; set; }


    }
}
