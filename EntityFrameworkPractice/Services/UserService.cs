using EntityFrameworkPractice.Contexts;
using EntityFrameworkPractice.Exceptions;
using EntityFrameworkPractice.Models;
using EntityFrameworkPractice.Persistance.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.Services
{
    public class UserService : IUserService
    {
        private readonly EFPContext _context;

        public UserService(EFPContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with id {id} not found");
            }
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.Posts).ToListAsync();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new EntityNotFoundException($"User with id {user.Id} not found");
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.IsEmailVerified = user.IsEmailVerified;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with id {id} not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
