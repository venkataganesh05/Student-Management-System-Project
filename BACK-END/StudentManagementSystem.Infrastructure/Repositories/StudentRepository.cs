using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Core.Entities;
using StudentManagementSystem.Infrastructure.Data;

using StudentManagementSystem.Core.Interfaces.Repositories;

public class StudentRepository : IStudentRepository   // ✅ public + implements interface
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAll()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student> GetById(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task Add(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Student student)
    {
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }
}