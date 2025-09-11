using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Department
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.Id);
            if (department == null || department.IsDeleted) return false;

            // Update properties via reflection
            var properties = typeof(Department).GetProperties();
            properties.FirstOrDefault(p => p.Name == "Name")?.SetValue(department, request.Department.Name);
            properties.FirstOrDefault(p => p.Name == "Description")?.SetValue(department, request.Department.Description);
            properties.FirstOrDefault(p => p.Name == "ManagerId")?.SetValue(department, request.Department.ManagerId);
            properties.FirstOrDefault(p => p.Name == "IsActive")?.SetValue(department, request.Department.IsActive);

            _unitOfWork.DepartmentRepository.Update(department);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
