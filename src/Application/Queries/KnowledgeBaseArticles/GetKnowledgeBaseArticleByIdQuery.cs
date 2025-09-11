using Application.DTOs.KnowledgeBaseArticle;
using MediatR;

namespace Application.Queries.KnowledgeBaseArticles
{
    public class GetKnowledgeBaseArticleByIdQuery : IRequest<KnowledgeBaseArticleDto?>
    {
        public Guid Id { get; set; }
    }
}
