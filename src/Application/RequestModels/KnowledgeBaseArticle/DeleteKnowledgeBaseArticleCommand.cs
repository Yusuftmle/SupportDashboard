using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.RequestModels.KnowledgeBaseArticle
{
    public class DeleteKnowledgeBaseArticleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
