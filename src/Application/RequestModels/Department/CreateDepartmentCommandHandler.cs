using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Department
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department();

            // Set properties via reflection
            var properties = typeof(Department).GetProperties();
            properties.FirstOrDefault(p => p.Name == "Name")?.SetValue(department, request.Department.Name);
            properties.FirstOrDefault(p => p.Name == "Description")?.SetValue(department, request.Department.Description);
            properties.FirstOrDefault(p => p.Name == "ManagerId")?.SetValue(department, request.Department.ManagerId);

            await _unitOfWork.DepartmentRepository.AddAsync(department);
            await _unitOfWork.CommitAsync(cancellationToken);

            return department.Id;
        }
    }

}
