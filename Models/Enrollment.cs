namespace UniversityApp.Models
{
    public class Enrollment
    {
        public Student Student { get; set; } = null!;
        public int StudentId { get; set; }
        public Course Course { get; set; } = null!;
        public int CourseId { get; set; }
    }
}