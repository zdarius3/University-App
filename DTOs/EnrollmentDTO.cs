namespace UniversityApp.DTOs
{
    public class EnrollmentDTO
    {
        public CourseDTO Course { get; init; } = null!;
        public int CourseId { get; init; }
        public StudentDTO Student { get; init; } = null!;
        public int StudentId { get; init; }

    }
}