using StudentManagementSystem.Core.DTOs;
using StudentManagementSystem.Core.Interfaces.Repositories;
using StudentManagementSystem.Core.Interfaces.Services;

namespace StudentManagementSystem.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Login(LoginRequestDto dto)
        {
            var user = await _userRepository.GetByEmail(dto.Email);

            if (user == null || user.Password != dto.Password)
                return null;

            return _jwtService.GenerateToken(user.Email);
        }
    }
}