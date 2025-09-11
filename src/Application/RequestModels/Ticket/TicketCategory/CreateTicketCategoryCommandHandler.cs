using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket.TicketCategory
{
    public class CreateTicketCategoryCommandHandler : IRequestHandler<CreateTicketCategoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTicketCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new TicketCategory();

            var properties = typeof(TicketCategory).GetProperties();
            properties.FirstOrDefault(p => p.Name == "Name")?.SetValue(category, request.Category.Name);
            properties.FirstOrDefault(p => p.Name == "Description")?.SetValue(category, request.Category.Description);
            properties.FirstOrDefault(p => p.Name == "DepartmentId")?.SetValue(category, request.Category.DepartmentId);
            properties.FirstOrDefault(p => p.Name == "EstimatedResolutionHours")?.SetValue(category, request.Category.EstimatedResolutionHours);

            await _unitOfWork.TicketCategoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync(cancellationToken);

            return category.Id;
        }
    }

}
