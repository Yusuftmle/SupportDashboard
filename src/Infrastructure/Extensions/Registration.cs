using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Infrastructure.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BlazorTicketContext>(conf =>
            {
                var conStr = configuration["BlazorSozlukDbConnectionStrings"];
                conf.UseSqlServer(conStr);
            });



            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IKnowledgeBaseArticleRepository, KnowledgeBaseArticleRepository>();
            services.AddScoped<INotificationSettingsRepository, NotificationSettingsRepository>();
            services.AddScoped<ISLAARepository, SLARepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketAttachmentRepository, TicketAttachmentRepository>();
            services.AddScoped<ITicketCategoryRepository, TicketCategoryRepository>();
            services.AddScoped<ITicketCommentRepository, TicketCommentRepository>();
            services.AddScoped<ITicketEscalationRepository, TicketEscalationRepository>();
            services.AddScoped<ITicketTagRepository, TicketTagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkingHoursRepository, WorkingHoursRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}

