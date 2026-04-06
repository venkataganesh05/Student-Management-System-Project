using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Core.DTOs;
using StudentManagementSystem.Core.Entities;
using StudentManagementSystem.Core.Interfaces.Services;

namespace StudentManagementSystem.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // ✅ GET: api/student
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        // ✅ GET: api/student/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
                return NotFound($"Student with ID {id} not found");

            return Ok(student);
        }

        // ✅ POST: api/student
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _studentService.AddStudent(dto);

            return Ok(result);
        }

        // ✅ PUT: api/students/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updated = await _studentService.UpdateStudent(id, dto);
            if (!updated)
                return NotFound(new { message = $"Student with ID {id} not found" });
            return Ok(new { message = $"Student {id} updated successfully" });
        }

        // ✅ DELETE: api/students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteStudent(id);
            if (!deleted)
                return NotFound(new { message = $"Student with ID {id} not found" });
            return Ok(new { message = $"Student {id} deleted successfully" });
        }
    }
}