using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.User;
using MediatR;

namespace Application.RequestModels.User
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public CreateUserDto User { get; set; }
    }
}
