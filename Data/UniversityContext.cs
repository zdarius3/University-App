using UniversityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityApp.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();


        //empty constructor body, only requires the type of connection
        public UniversityContext(DbContextOptions<UniversityContext> options) :
            base(options)
        { }

        //this tells the DbContext the relations between each DbSet
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(enrollment =>
                    new { enrollment.StudentId, enrollment.CourseId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(enrollment => enrollment.Student)
                .WithMany(student => student.Enrollments)
                .HasForeignKey(enrollment => enrollment.StudentId);

            modelBuilder.Entity<Enrollment>()
            .HasOne(enrollment => enrollment.Course)
            .WithMany(course => course.Enrollments)
            .HasForeignKey(enrollment => enrollment.CourseId);
        }
    }
}