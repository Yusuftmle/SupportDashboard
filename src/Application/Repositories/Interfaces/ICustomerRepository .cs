using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetByEmailAsync(string email);
        Task<IEnumerable<Customer>> GetActiveCustomersAsync();
        Task<bool> EmailExistsAsync(string email);
    }
}
