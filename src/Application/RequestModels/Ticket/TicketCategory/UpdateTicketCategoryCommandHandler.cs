using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket.TicketCategory
{
    public class UpdateTicketCategoryCommandHandler : IRequestHandler<UpdateTicketCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateTicketCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.TicketCategoryRepository.GetByIdAsync(request.Id);
            if (category == null || category.IsDeleted) return false;

            var properties = typeof(TicketCategory).GetProperties();
            properties.FirstOrDefault(p => p.Name == "Name")?.SetValue(category, request.Category.Name);
            properties.FirstOrDefault(p => p.Name == "Description")?.SetValue(category, request.Category.Description);
            properties.FirstOrDefault(p => p.Name == "DepartmentId")?.SetValue(category, request.Category.DepartmentId);
            properties.FirstOrDefault(p => p.Name == "IsActive")?.SetValue(category, request.Category.IsActive);
            properties.FirstOrDefault(p => p.Name == "EstimatedResolutionHours")?.SetValue(category, request.Category.EstimatedResolutionHours);

            _unitOfWork.TicketCategoryRepository.Update(category);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
