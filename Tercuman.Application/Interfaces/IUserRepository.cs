using Tercuman.Domain.Entities;

namespace Tercuman.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
        Task<List<User>> GetAllAsync();
        IQueryable<User> Query();
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}
