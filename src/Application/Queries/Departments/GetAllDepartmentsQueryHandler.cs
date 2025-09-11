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
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var query = _departmentRepository.AsQueryable()
                .AsNoTracking()
                .Where(d => !d.IsDeleted);

            if (request.IsActive.HasValue)
                query = query.Where(d => d.IsActive == request.IsActive.Value);

            var result = await query
                .OrderBy(d => d.Name)
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
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
