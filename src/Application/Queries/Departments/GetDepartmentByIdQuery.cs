using Application.DTOs.Department;
using MediatR;

namespace Application.Queries.Departments
{
    public class GetDepartmentByIdQuery : IRequest<DepartmentDto?>
    {
        public Guid Id { get; set; }
    }
}
