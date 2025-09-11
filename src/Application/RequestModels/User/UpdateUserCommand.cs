using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.User;
using MediatR;

namespace Application.RequestModels.User
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateUserDto User { get; set; }
    }
}
