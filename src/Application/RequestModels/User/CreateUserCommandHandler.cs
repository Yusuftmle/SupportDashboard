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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<UserRole>(request.User.Role, out var role))
                role = UserRole.User;

            var user = new User(request.User.FullName, request.User.Email, role);
            user.UpdateProfile(request.User.PhoneNumber, request.User.Department);

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CommitAsync(cancellationToken);

            return user.Id;
        }
    }
}
