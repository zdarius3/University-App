namespace UniversityApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}
