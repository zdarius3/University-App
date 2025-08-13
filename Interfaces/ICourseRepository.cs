using UniversityApp.DTOs;
using UniversityApp.Models;

namespace UniversityApp.DTOs
{
    public interface ICourseRepository
    {
        public Task<IEnumerable<CourseDTO>> GetAllAsync();

        public Task<CourseDTO> GetByIdAsync(int id);

        public Task<Course> CreateAsync(CreateCourseDTO cCourseDto);

        public Task<Course> UpdateAsync(UpdateCourseDTO uCourseDTO);

        public Task<Course> DeleteAsync(int id);
    }
}