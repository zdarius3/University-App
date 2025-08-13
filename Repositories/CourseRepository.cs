using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;
using UniversityApp.Data;
using UniversityApp.DTOs;
using UniversityApp.Interfaces;

namespace UniversityApp.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public UniversityContext _context;

        public CourseRepository(UniversityContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            var courses = await _context.Courses.ToListAsync();

            return courses.Select(c => new CourseDTO
            {
                Id = c.Id,
                Title = c.Title
            });
        }

        public async Task<CourseDTO> GetByIdAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                throw new KeyNotFoundException("Course not found");
            }

            return new CourseDTO
            {
                Id = course.Id,
                Title = course.Title
            };
        }

        public async Task<Course> CreateAsync(CreateCourseDTO cCourseDTO)
        {
            var newCourse = new Course
            {
                Title = cCourseDTO.Title,
                Description = cCourseDTO.Description
            };
            await _context.Courses.AddAsync(newCourse);

            await _context.SaveChangesAsync();
            return newCourse;
        }

        public async Task<Course> UpdateAsync(UpdateCourseDTO uCourseDto)
        {
            //search course, if not found throw exception
            var courseToUpdate = await _context.Courses.FindAsync(uCourseDto.Id) ??
                throw new KeyNotFoundException("Course not found");

            if (uCourseDto.Title != null)
            {
                courseToUpdate.Title = uCourseDto.Title;
            }
            if (uCourseDto.Description != null)
            {
                courseToUpdate.Description = uCourseDto.Description;
            }

            await _context.SaveChangesAsync();
            return courseToUpdate;
        }

        public async Task<Course> DeleteAsync(int id)
        {
            //search course, if not found throw exception
            var courseToDelete = await _context.Courses.FindAsync(id) ??
                throw new KeyNotFoundException("Course not found");

            _context.Courses.Remove(courseToDelete);
            await _context.SaveChangesAsync();
            return courseToDelete;
        }
    }
}