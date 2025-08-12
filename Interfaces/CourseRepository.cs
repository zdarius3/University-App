using UniversityApp.DTOs;

namespace UniversityApp.DTOs
{
    public interface CourseRepository
    {
        public CourseDTO GetCourseById(int id);

        public void CreateCourse(CreateCourseDTO courseDto);

        public void UpdateCourse(int id, CreateCourseDTO courseDto);

        public void DeleteCourse(int id);
    }
}