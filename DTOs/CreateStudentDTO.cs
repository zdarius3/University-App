namespace UniversityApp.DTOs
{
    //info required only when creating a new student
    public class CreateStudentDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}