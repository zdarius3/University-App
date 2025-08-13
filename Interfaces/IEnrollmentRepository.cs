using UniversityApp.DTOs;
using UniversityApp.Models;
namespace UniversityApp.Repositories
{
    public interface IEnrollmentRepository
    {
        public Task<IEnumerable<Enrollment>> GetAllAsync();

        public Task<Enrollment> GetByIdsAsync(int studentId, int courseId);

        public Task EnrollStudentAsync(int studentId, int courseId);

        public Task UnenrollStudentAsync(int studentId, int courseId);
    }
}
