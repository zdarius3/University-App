namespace UniversityApp.DTOs
{
    //info from the courses that will be showed 
    public class CourseDTO
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;   
    }
}