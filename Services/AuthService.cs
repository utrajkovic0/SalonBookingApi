using Microsoft.EntityFrameworkCore;
using SalonBookingApi.Data;
using SalonBookingApi.DTOs;
using SalonBookingApi.Models;

namespace SalonBookingApi.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(RegisterDto request)
        {
            if  (await _context.Users.AnyAsync(u => u.Username == request.Username)) return false;

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User user = new()
            {
                Username = request.Username,
                PasswordHash = hash,
                Role = "User"
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
