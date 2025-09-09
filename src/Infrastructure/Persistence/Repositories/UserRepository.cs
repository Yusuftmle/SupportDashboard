using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<User>())
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await FirstOrDefaultAsync(u => u.FullName == username);
        }

        
        public async Task<IEnumerable<User>> GetUsersByRoleAsync(UserRole role)
        {
            return await GetList(u => u.Role == role);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await AnyAsync(u => u.FullName == username);
        }
    }
}
