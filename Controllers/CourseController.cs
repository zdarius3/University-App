using UniversityApp.Models;
using UniversityApp.Interfaces;
using UniversityApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace UniversityApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;

        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepo.GetAllAsync();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            try
            {
                var course = await _courseRepo.GetByIdAsync(id);
                return Ok(course);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDTO cCourseDTO)
        {
            if (cCourseDTO == null)
            {
                return BadRequest("Invalid course data.");
            }

            var newCourse = await _courseRepo.CreateAsync(cCourseDTO);
            return CreatedAtAction(nameof(CreateCourse), new { id = newCourse.Id }, newCourse);
        }

        [HttpPut("UpdateCourse")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseDTO uCourseDTO)
        {
            if (uCourseDTO == null)
            {
                return BadRequest("Invalid course data.");
            }

            try
            {
                var updatedCourse = await _courseRepo.UpdateAsync(uCourseDTO);
                return Ok(updatedCourse);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("DeleteCourse{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                var deletedCourse = await _courseRepo.DeleteAsync(id);
                return Ok(deletedCourse);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

    }
}