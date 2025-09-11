using Application.DTOs.KnowledgeBaseArticle;
using MediatR;

namespace Application.Queries.KnowledgeBaseArticles
{
    public class GetAll : IRequest<List<KnowledgeBaseArticleDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
