using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Department
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.Id);
            if (department == null || department.IsDeleted) return false;

            // Check if department has active users
            var hasActiveUsers = department.Users.Any(u => !u.IsDeleted);
            if (hasActiveUsers)
                return false; // Cannot delete department with active users

            // Soft delete
            department.IsDeleted = true;
            _unitOfWork.DepartmentRepository.Update(department);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
