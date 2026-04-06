using StudentManagementSystem.Core.DTOs;

namespace StudentManagementSystem.Core.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudents();
        Task<StudentDto> GetStudentById(int id);
        Task<StudentDto> AddStudent(CreateStudentDto dto);
        Task<bool> UpdateStudent(int id, UpdateStudentDto dto);
        Task<bool> DeleteStudent(int id);
    }
}