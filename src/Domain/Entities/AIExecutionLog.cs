using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AIExecutionLog : BaseEntity
    {
        public Guid? TicketId { get; private set; }
        public string WorkflowName { get; private set; } = string.Empty;
        public string? StepName { get; private set; }
        public string? InputData { get; private set; }
        public string? OutputData { get; private set; }
        public int ExecutionTimeMs { get; private set; }
        public string Status { get; private set; } = string.Empty; // Success, Failed, Timeout
        public string? ErrorMessage { get; private set; }

        public Ticket? Ticket { get; private set; }

        public AIExecutionLog(string workflowName, string status)
        {
            WorkflowName = workflowName;
            Status = status;
        }
        public void SetTicket(Guid ticketId)
        {
            TicketId = ticketId;
        }

        public void SetStep(string stepName)
        {
            StepName = stepName;
        }

        public void SetInputData(string inputData)
        {
            InputData = inputData;
        }

        public void SetOutputData(string outputData)
        {
            OutputData = outputData;
        }

        public void SetExecutionTime(int milliseconds)
        {
            ExecutionTimeMs = milliseconds;
        }

        public void SetError(string errorMessage)
        {
            Status = "Failed";
            ErrorMessage = errorMessage;
        }

        public void MarkAsSuccess()
        {
            Status = "Success";
        }
    }
}
