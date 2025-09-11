using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (user == null || user.IsDeleted) return false;

            if (!string.IsNullOrEmpty(request.User.FullName))
                user.GetType().GetProperty("FullName")?.SetValue(user, request.User.FullName);

            if (!string.IsNullOrEmpty(request.User.Email))
                user.GetType().GetProperty("Email")?.SetValue(user, request.User.Email);

            if (!string.IsNullOrEmpty(request.User.Role) &&
                Enum.TryParse<UserRole>(request.User.Role, out var role))
                user.UpdateRole(role);

            user.UpdateProfile(request.User.PhoneNumber, request.User.Department);

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
