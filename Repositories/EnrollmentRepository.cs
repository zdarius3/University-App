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

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> GetByIdsAsync(int studentId, int courseId)
        {
            //search enrollment, if not found throw exception
            var enrollment = await _context.Enrollments.FindAsync(studentId, courseId) ??
                throw new KeyNotFoundException("Enrollment not found");

            return enrollment;
         }

        public async Task EnrollStudentAsync(int studentId, int courseId)
        {
            //search entities, if not found throw exception
            var student = await _context.Students.FindAsync(studentId) ??
                throw new KeyNotFoundException("Student not found");
            var course = await _context.Courses.FindAsync(courseId) ??
                throw new KeyNotFoundException("Course not found");
            Enrollment enrollment = new Enrollment
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
        }

        public async Task UnenrollStudentAsync(int studentId, int courseId)
        {
            //search entities, if not found throw exception
            var student = await _context.Students.FindAsync(studentId) ??
                throw new KeyNotFoundException("Student not found");
            var course = await _context.Courses.FindAsync(courseId) ??
                throw new KeyNotFoundException("Course not found");
            var enrollment = await _context.Enrollments.FindAsync(studentId, courseId) ??
                throw new KeyNotFoundException("Enrollment not found");

            //save chenges
            student.Enrollments.Remove(enrollment);
            course.Enrollments.Remove(enrollment);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}