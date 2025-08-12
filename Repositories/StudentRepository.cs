using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;
using UniversityApp.Data;
using UniversityApp.DTOs;
using UniversityApp.Interfaces;

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

    public async Task<StudentDTO?> GetByIdAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return null;
        }   

        return new StudentDTO
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email is null ? "No Email" : student.Email
        };
    }

    public async Task CreateAsync(CreateStudentDTO studentDto)
    {
        _context.Students.Add(new Student
        {
            Name = studentDto.Name,
            Email = studentDto.Email
        });
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UpdateStudentDTO studentDto)
    {
        var studentToUpdate = await _context.Students.FindAsync(studentDto.Id);

        if (studentToUpdate == null)
        {
            throw new KeyNotFoundException("Student not found");
        }

        if (studentDto.Name != null)
        {
            studentToUpdate.Name = studentDto.Name;
        }
        if (studentDto.Email != null)
        {
            studentToUpdate.Email = studentDto.Email;
        }   
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var studentToDelete = await _context.Students.FindAsync(id) ??
            throw new KeyNotFoundException("Student not found");
        _context.Students.Remove(studentToDelete);
        await _context.SaveChangesAsync();
    }
}