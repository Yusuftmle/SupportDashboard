using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.AIExecutionLog;
using MediatR;

namespace Application.RequestModels.AIExecutionLog
{
    public class CreateAIExecutionLogCommand : IRequest<Guid>
    {
        public CreateAIExecutionLogDto Log { get; set; }
    }
}
