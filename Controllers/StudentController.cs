using UniversityApp.Models;
using UniversityApp.Interfaces;
using UniversityApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace UniversityApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepo.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _studentRepo.GetByIdAsync(id);
                return Ok(student);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Invalid student data.");
            }

            var newStudent = await _studentRepo.CreateAsync(studentDto);
            return CreatedAtAction(nameof(CreateStudent), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentDTO uStudentDto)
        {
            if (uStudentDto == null)
            {
                return BadRequest("Invalid student data.");
            }

            try
            {
                var updatedStudent = await _studentRepo.UpdateAsync(uStudentDto);
                return Ok(updatedStudent);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("DeleteStudent{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var deletedStudent = await _studentRepo.DeleteAsync(id);
                return Ok(deletedStudent);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}