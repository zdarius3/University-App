using UniversityApp.Models;
using UniversityApp.Interfaces;
using UniversityApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Repositories;

namespace UniversityApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepo;

        public EnrollmentController(IEnrollmentRepository enrollmentRepo)
        {
            _enrollmentRepo = enrollmentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var enrollments = await _enrollmentRepo.GetAllAsync();
            return Ok(enrollments);
        }

        [HttpGet("student{studentId}-course{courseId}")]
        public async Task<IActionResult> GetEnrollmentByIds(int studentId, int courseId)
        {
            try
            {
                var enrollment = await _enrollmentRepo.GetByIdsAsync(studentId, courseId);
                return Ok(enrollment);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("EnrollStudent")]
        public async Task<IActionResult> EnrollStudent(int studentId, int courseId)
        {
            try
            {
                var enrollment = await _enrollmentRepo.EnrollStudentAsync(studentId, courseId);
                return CreatedAtAction(nameof(GetEnrollmentByIds), new
                    { studentId = enrollment.StudentId, courseId = enrollment.CourseId }, enrollment);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("UnenrollStudent{studentId}-course{courseId}")]
        public async Task<IActionResult> UnenrollStudent(int studentId, int courseId)
        {
            try
            {
                var enrollment = await _enrollmentRepo.UnenrollStudentAsync(studentId, courseId);
                return Ok(enrollment);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}