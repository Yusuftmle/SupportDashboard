using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<Customer>())
        {
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<IEnumerable<Customer>> GetActiveCustomersAsync()
        {
            return await GetList(c => c.IsActive);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await AnyAsync(c => c.Email == email);
        }
    }
}
