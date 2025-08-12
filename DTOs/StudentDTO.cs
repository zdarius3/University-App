namespace UniversityApp.DTOs
{
    //info from the student that will be showed 
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}