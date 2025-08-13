using UniversityApp.DTOs;
using UniversityApp.Models;

namespace UniversityApp.Interfaces
{
    //interface that defines the methods to manage the student information
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        
        Task<StudentDTO> GetByIdAsync(int id);

        Task<Student> CreateAsync(CreateStudentDTO cStudentDto);

        Task<Student> UpdateAsync(UpdateStudentDTO uStudentDto);

        Task<Student> DeleteAsync(int id);
    }
}