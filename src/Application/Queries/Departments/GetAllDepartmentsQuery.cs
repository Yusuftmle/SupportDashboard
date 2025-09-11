using Application.DTOs.Department;
using MediatR;

namespace Application.Queries.Departments
{
    public class GetAll : IRequest<List<DepartmentDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
