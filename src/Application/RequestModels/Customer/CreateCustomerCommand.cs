using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Customer;
using MediatR;

namespace Application.RequestModels.Customer
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public CreateCustomerDto Customer { get; set; }
    }
}
