using EntityFrameworkPractice.Models;

namespace EntityFrameworkPractice.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}
