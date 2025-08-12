using UniversityApp.DTOs;

public interface EnrollmentRepository
{
    public void EnrollStudent(int studentId, int courseId);

    public void UnenrollStudent(int studentId, int courseId);

    public void EnrollCourse(int courseId, int studentId);

    public void UnenrollCourse(int courseId, int studentId);

    public IEnumerable<CourseDTO> GetCoursesByStudentId(int studentId);
    
    public IEnumerable<StudentDTO> GetStudentsByCourseId(int courseId);
}