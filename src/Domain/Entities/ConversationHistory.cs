using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ConversationHistory:BaseEntity
    {
        public Guid SessionId { get; private set; }
        public Guid? UserId { get; private set; }
        public string Message { get; private set; } = string.Empty;
        public bool IsFromUser { get; private set; }
        public int? TokenCount { get; private set; }
        public string? PluginUsed { get; private set; }

        public User? User { get; private set; }

        // Parameterless constructor for EF Core
        private ConversationHistory() { }

        // Public constructor
        public ConversationHistory(Guid sessionId, string message, bool isFromUser)
        {
            SessionId = sessionId;
            Message = message;
            IsFromUser = isFromUser;
        }

        public void SetTokenCount(int tokenCount)
        {
            TokenCount = tokenCount;
        }

        public void SetPluginUsed(string pluginName)
        {
            PluginUsed = pluginName;
        }

        public void SetUser(Guid userId)
        {
            UserId = userId;
        }
    }
}
