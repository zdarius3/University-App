namespace UniversityApp.DTOs
{
    //info required only when creating a new student
    public class CreateStudentDTO
    {
        public string Name { get; init; } = null!;
        public string Email { get; init; } = null!;
    }
}