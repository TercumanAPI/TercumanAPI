using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Entities;

namespace Tercuman.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);   // BUNU EKLE
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}
