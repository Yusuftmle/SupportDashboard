using Application.DTOs.User;
using MediatR;

namespace Application.Queries.Users
{
    public class GetUserByIdQuery : IRequest<UserDto?>
    {
        public Guid Id { get; set; }
    }
}
