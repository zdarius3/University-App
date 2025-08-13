using UniversityApp.DTOs;

namespace UniversityApp.Interfaces
{
    //interface that defines the methods to manage the student information
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        
        Task<StudentDTO> GetByIdAsync(int id);

        Task CreateAsync(CreateStudentDTO cStudentDto);

        Task UpdateAsync(UpdateStudentDTO uStudentDto);

        Task DeleteAsync(int id);
    }
}