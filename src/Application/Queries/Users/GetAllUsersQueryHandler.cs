using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.User;
using Application.Repositories.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Queries.Users
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _userRepository.AsQueryable()
                .AsNoTracking()
                .Where(u => !u.IsDeleted);

            if (!string.IsNullOrEmpty(request.Role) && Enum.TryParse<UserRole>(request.Role, out var role))
                query = query.Where(u => u.Role == role);

            if (!string.IsNullOrEmpty(request.Department))
                query = query.Where(u => u.Department == request.Department);

            var result = await query
                .OrderBy(u => u.FullName)
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
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
