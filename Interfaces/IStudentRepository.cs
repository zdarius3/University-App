using UniversityApp.DTOs;

namespace UniversityApp.Interfaces
{
    //interface that defines the methods to manage the student information
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO?> GetByIdAsync(int id);

        Task CreateAsync(CreateStudentDTO studentDto);

        Task UpdateAsync(UpdateStudentDTO studentDto);

        Task DeleteAsync(int id);
    }
}