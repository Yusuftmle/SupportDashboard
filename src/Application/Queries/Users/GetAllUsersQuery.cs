using MediatR;

namespace Application.Queries.Users
{
    public class GetAll : IRequest<List<UserDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
