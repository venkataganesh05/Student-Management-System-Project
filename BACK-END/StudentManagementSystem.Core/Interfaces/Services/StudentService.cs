using StudentManagementSystem.Core.DTOs;
using StudentManagementSystem.Core.Entities;
using StudentManagementSystem.Core.Interfaces.Repositories;
using StudentManagementSystem.Core.Interfaces.Services;

namespace StudentManagementSystem.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            var students = await _repository.GetAll();

            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                Course = s.Course,
                CreatedDate = s.CreatedDate
            });
        }

        public async Task<StudentDto?> GetStudentById(int id)
        {
            var student = await _repository.GetById(id);
            if (student == null) return null;

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Course = student.Course,
                CreatedDate = student.CreatedDate
            };
        }

        public async Task<StudentDto> AddStudent(CreateStudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.UtcNow
            };

            await _repository.Add(student);

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Course = student.Course,
                CreatedDate = student.CreatedDate
            };
        }

        public async Task<bool> UpdateStudent(int id, UpdateStudentDto dto)
        {
            var student = await _repository.GetById(id);
            if (student == null) return false;

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;
            student.Course = dto.Course;

            await _repository.Update(student);
            return true;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _repository.GetById(id);
            if (student == null) return false;

            await _repository.Delete(student);
            return true;
        }
    }
}