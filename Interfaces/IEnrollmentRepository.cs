using UniversityApp.DTOs;
using UniversityApp.Models;
namespace UniversityApp.Repositories
{
    public interface IEnrollmentRepository
    {
        public Task<IEnumerable<EnrollmentDTO>> GetAllAsync();

        public Task<EnrollmentDTO> GetByIdsAsync(int studentId, int courseId);

        public Task<EnrollmentDTO> EnrollStudentAsync(int studentId, int courseId);

        public Task<EnrollmentDTO> UnenrollStudentAsync(int studentId, int courseId);
    }
}
