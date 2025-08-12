namespace UniversityApp.DTOs
{
    //info from the student that will be showed 
    public class UpdateStudentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}