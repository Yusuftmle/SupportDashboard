using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.KnowledgeBaseArticle;
using MediatR;

namespace Application.RequestModels.KnowledgeBaseArticle
{
    public class CreateKnowledgeBaseArticleCommand : IRequest<Guid>
    {
        public CreateKnowledgeBaseArticleDto Article { get; set; }
    }
}
