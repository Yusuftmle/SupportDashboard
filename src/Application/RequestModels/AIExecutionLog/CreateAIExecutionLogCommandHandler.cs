using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.AIExecutionLog
{
    public class CreateAIExecutionLogCommandHandler : IRequestHandler<CreateAIExecutionLogCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAIExecutionLogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAIExecutionLogCommand request, CancellationToken cancellationToken)
        {
            var log = new AIExecutionLog(request.Log.WorkflowName, request.Log.Status);

            if (request.Log.TicketId.HasValue)
                log.SetTicket(request.Log.TicketId.Value);

            if (!string.IsNullOrEmpty(request.Log.StepName))
                log.SetStep(request.Log.StepName);

            if (!string.IsNullOrEmpty(request.Log.InputData))
                log.SetInputData(request.Log.InputData);

            if (!string.IsNullOrEmpty(request.Log.OutputData))
                log.SetOutputData(request.Log.OutputData);

            log.SetExecutionTime(request.Log.ExecutionTimeMs);

            if (!string.IsNullOrEmpty(request.Log.ErrorMessage))
                log.SetError(request.Log.ErrorMessage);
            else if (request.Log.Status == "Success")
                log.MarkAsSuccess();

            await _unitOfWork.AIExecutionLogRepository.AddAsync(log);
            await _unitOfWork.CommitAsync(cancellationToken);

            return log.Id;
        }
    }
}
