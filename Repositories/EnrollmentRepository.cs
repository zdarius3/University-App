using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;
using UniversityApp.Data;
using UniversityApp.DTOs;
using UniversityApp.Interfaces;

namespace UniversityApp.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public UniversityContext _context;

        public EnrollmentRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EnrollmentDTO>> GetAllAsync()
        {
            var enrollments = await _context.Enrollments
                                .AsNoTracking()
                                .Include(e => e.Student)
                                .Include(e => e.Course)
                                .ToListAsync();
                
            return enrollments.Select(e => new EnrollmentDTO
            {
                Course = new CourseDTO
                {
                    Id = e.Course.Id,
                    Title = e.Course.Title,
                    Description = e.Course.Description
                },
                CourseId = e.CourseId,
                Student = new StudentDTO
                {
                    Id = e.Student.Id,
                    Name = e.Student.Name,
                    Email = e.Student.Email is null ? "No Email" : e.Student.Email
                },
                StudentId = e.StudentId
            });
        }

        public async Task<EnrollmentDTO> GetByIdsAsync(int studentId, int courseId)
        {
            var enrollment = await _context.Enrollments
                                .AsNoTracking()
                                .Include(e => e.Student)
                                .Include(e => e.Course)
                                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId)
                                ?? throw new KeyNotFoundException("Enrollment not found");
            var student = enrollment.Student;
            var course = enrollment.Course;

            return new EnrollmentDTO
            {
                Course = new CourseDTO
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description
                },
                CourseId = course.Id,
                Student = new StudentDTO
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email is null ? "No Email" : student.Email
                },
                StudentId = student.Id
            };
         }

        public async Task<EnrollmentDTO> EnrollStudentAsync(int studentId, int courseId)
        {
            //search entities, if not found throw exception
            var student = await _context.Students.FindAsync(studentId) ??
                throw new KeyNotFoundException("Student not found");
            var course = await _context.Courses.FindAsync(courseId) ??
                throw new KeyNotFoundException("Course not found");
            var enrollment = new Enrollment
            {
                Student = student,
                StudentId = student.Id,
                Course = course,
                CourseId = course.Id
            };

            //save chenges
            student.Enrollments.Add(enrollment);
            course.Enrollments.Add(enrollment);
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();

            return new EnrollmentDTO
            {
                Course = new CourseDTO
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description
                },
                CourseId = course.Id,
                Student = new StudentDTO
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email is null ? "No Email" : student.Email
                },
                StudentId = student.Id
            };
        }

        public async Task<EnrollmentDTO> UnenrollStudentAsync(int studentId, int courseId)
        {
            //search entities, if not found throw exception
            var enrollment = await _context.Enrollments.FindAsync(studentId, courseId) ??
                throw new KeyNotFoundException("Enrollment not found");
            var student = await _context.Students.FindAsync(studentId) ??
                throw new KeyNotFoundException("Student not found");
            var course = await _context.Courses.FindAsync(courseId) ??
                throw new KeyNotFoundException("Course not found");
           

            //save chenges
            student.Enrollments.Remove(enrollment);
            course.Enrollments.Remove(enrollment);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return new EnrollmentDTO
            {
                Course = new CourseDTO
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description
                },
                CourseId = course.Id,
                Student = new StudentDTO
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email is null ? "No Email" : student.Email
                },
                StudentId = student.Id
            };
        }
    }
}