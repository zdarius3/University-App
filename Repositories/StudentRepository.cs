using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;
using UniversityApp.Data;
using UniversityApp.DTOs;
using UniversityApp.Interfaces;

namespace UniversityApp.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public UniversityContext _context;

        public StudentRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _context.Students.ToListAsync();

            return students.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email is null ? "No Email" : s.Email
            });
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id) ??
                throw new KeyNotFoundException("Student not found");

            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email is null ? "No Email" : student.Email
            };
        }

        public async Task<Student> CreateAsync(CreateStudentDTO cStudentDto)
        {
            var newStudent = new Student
            {
                Name = cStudentDto.Name,
                Email = cStudentDto.Email
            };
            _context.Students.Add(newStudent);

            await _context.SaveChangesAsync();
            return newStudent;
        }

        public async Task<Student> UpdateAsync(UpdateStudentDTO uStudentDto)
        {
            //search student, if not found throw an exception
            var studentToUpdate = await _context.Students.FindAsync(uStudentDto.Id) ??
                throw new KeyNotFoundException("Student not found");

            if (uStudentDto.Name != null)
            {
                studentToUpdate.Name = uStudentDto.Name;
            }
            if (uStudentDto.Email != null)
            {
                studentToUpdate.Email = uStudentDto.Email;
            }

            await _context.SaveChangesAsync();
            return studentToUpdate;
        }

        public async Task<Student> DeleteAsync(int id)
        {
            //search student, if not found throw an exception
            var studentToDelete = await _context.Students.FindAsync(id) ??
                throw new KeyNotFoundException("Student not found");

            _context.Students.Remove(studentToDelete);
            await _context.SaveChangesAsync();
            return studentToDelete;
        }
    }
}