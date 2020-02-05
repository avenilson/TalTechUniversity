﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalTechUniversity.Models;

namespace TalTechUniversity.Data
{
    public class TalTechUniversityContext : DbContext
    {
        public TalTechUniversityContext (DbContextOptions<TalTechUniversityContext> options)
            : base(options)
        {
        }

        public DbSet<TalTechUniversity.Models.Student> Student { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
