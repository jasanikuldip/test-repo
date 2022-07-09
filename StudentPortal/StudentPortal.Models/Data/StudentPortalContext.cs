using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentPortal.Models.Data
{
    public partial class StudentPortalContext : DbContext
    {

        public StudentPortalContext(DbContextOptions<StudentPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Studentmsts { get; set; } = null!;
        public virtual DbSet<Teacher> Teachermsts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=StudentPortal;User Id=postgres;Password=admin123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("studentmst");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('student_id_seq'::regclass)");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(50)
                    .HasColumnName("middlename");

                entity.Property(e => e.Reporting).HasColumnName("reporting");

                entity.Property(e => e.Rollno)
                    .HasMaxLength(100)
                    .HasColumnName("rollno");

                entity.Property(e => e.Standard).HasColumnName("standard");

                entity.HasOne(d => d.ReportingNavigation)
                    .WithMany(p => p.Studentmsts)
                    .HasForeignKey(d => d.Reporting)
                    .HasConstraintName("fk_student_teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachermst");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('teacher_id_seq'::regclass)");

                entity.Property(e => e.Contact)
                    .HasMaxLength(20)
                    .HasColumnName("contact");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");
            });

            modelBuilder.HasSequence("student_id_seq");

            modelBuilder.HasSequence("teacher_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
