using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface IKnowledgeBaseArticleRepository : IGenericRepository<KnowledgeBaseArticle>
    {
        Task<IEnumerable<KnowledgeBaseArticle>> GetPublishedArticlesAsync();
        Task<IEnumerable<KnowledgeBaseArticle>> GetByCategoryAsync(TicketCategory category);
        Task<IEnumerable<KnowledgeBaseArticle>> SearchArticlesAsync(string searchTerm);
    }
}
