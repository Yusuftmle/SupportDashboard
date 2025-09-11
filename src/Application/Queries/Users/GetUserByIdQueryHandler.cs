using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.User;
using Application.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.AsQueryable()
                .AsNoTracking()
                .Where(u => u.Id == request.Id && !u.IsDeleted)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Department = u.Department,
                    LastLoginDate = u.LastLoginDate,
                    Role = u.Role.ToString(),
                    CreateDate = u.CreateDate,
                    CreatedTicketsCount = u.TicketsCreated.Count(t => !t.IsDeleted),
                    AssignedTicketsCount = u.TicketsAssigned.Count(t => !t.IsDeleted)
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }

}
