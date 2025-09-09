using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class KnowledgeBaseArticleRepository : GenericRepository<KnowledgeBaseArticle>, IKnowledgeBaseArticleRepository
    {
        public KnowledgeBaseArticleRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<KnowledgeBaseArticle>())
        {
        }

        public async Task<IEnumerable<KnowledgeBaseArticle>> GetPublishedArticlesAsync()
        {
            return await GetList(k => k.IsActive, orderBy: q => q.OrderByDescending(k => k.CreateDate));
        }

        public async Task<IEnumerable<KnowledgeBaseArticle>> GetByCategoryAsync(TicketCategory category)
        {
            return await GetList(k => k.Category == category && k.IsActive);
        }

        public async Task<IEnumerable<KnowledgeBaseArticle>> SearchArticlesAsync(string searchTerm)
        {
            return await GetList(k => k.IsActive &&
                (k.Name.Contains(searchTerm) || k.Description.Contains(searchTerm) ));
        }
    }
}
