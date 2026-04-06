using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Core.Entities;
using StudentManagementSystem.Core.Interfaces.Repositories;
using StudentManagementSystem.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}