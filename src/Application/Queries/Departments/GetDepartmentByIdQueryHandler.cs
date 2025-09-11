using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Department;
using Application.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.Departments
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto?>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDto?> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _departmentRepository.AsQueryable()
                .AsNoTracking()
                .Where(d => d.Id == request.Id && !d.IsDeleted)
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    IsActive = d.IsActive,
                    ManagerId = d.ManagerId,
                    ManagerName = d.Manager != null ? d.Manager.FullName : null,
                    UserCount = d.Users.Count(u => !u.IsDeleted),
                    CategoryCount = d.Categories.Count(c => !c.IsDeleted),
                    CreateDate = d.CreateDate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }

}
