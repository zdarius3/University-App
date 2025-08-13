namespace UniversityApp.DTOs
{
    //info from the courses that will be showed 
    public class CreateCourseDTO
    {
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
    }
}