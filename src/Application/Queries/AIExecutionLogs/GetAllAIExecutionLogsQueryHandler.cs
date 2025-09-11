using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.AIExecutionLog;
using MediatR;

namespace Application.Queries.AIExecutionLogs
{
    public class GetAllAIExecutionLogsQueryHandler : IRequestHandler<GetAllAIExecutionLogsQuery, List<AIExecutionLogDto>>
    {
        private readonly IAIExecutionLogRepository _repository;

        public GetAllAIExecutionLogsQueryHandler(IAIExecutionLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AIExecutionLogDto>> Handle(GetAllAIExecutionLogsQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.AsQueryable()
                .AsNoTracking()
                .Where(log => !log.IsDeleted);

            if (request.TicketId.HasValue)
                query = query.Where(log => log.TicketId == request.TicketId);

            if (!string.IsNullOrEmpty(request.WorkflowName))
                query = query.Where(log => log.WorkflowName == request.WorkflowName);

            if (!string.IsNullOrEmpty(request.Status))
                query = query.Where(log => log.Status == request.Status);

            if (request.StartDate.HasValue)
                query = query.Where(log => log.CreateDate >= request.StartDate);

            if (request.EndDate.HasValue)
                query = query.Where(log => log.CreateDate <= request.EndDate);

            var skip = (request.Page - 1) * request.PageSize;

            var result = await query
                .OrderByDescending(log => log.CreateDate)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(log => new AIExecutionLogDto
                {
                    Id = log.Id,
                    TicketId = log.TicketId,
                    WorkflowName = log.WorkflowName,
                    StepName = log.StepName,
                    InputData = log.InputData,
                    OutputData = log.OutputData,
                    ExecutionTimeMs = log.ExecutionTimeMs,
                    Status = log.Status,
                    ErrorMessage = log.ErrorMessage,
                    CreateDate = log.CreateDate,
                    TicketTitle = log.Ticket != null ? log.Ticket.Title : null
                })
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
