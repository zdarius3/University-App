namespace UniversityApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}