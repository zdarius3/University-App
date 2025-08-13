using UniversityApp.DTOs;
using UniversityApp.Models;

namespace UniversityApp.DTOs
{
    public interface ICourseRepository
    {
        public Task<IEnumerable<CourseDTO>> GetAllAsync();
        
        public Task<CourseDTO> GetByIdAsync(int id);

        public Task CreateAsync(CreateCourseDTO cCourseDto);

        public Task UpdateAsync(UpdateCourseDTO uCourseDTO);

        public Task DeleteAsync(int id);
    }
}