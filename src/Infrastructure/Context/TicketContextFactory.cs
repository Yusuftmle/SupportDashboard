using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    // Factory sınıfı - IDesignTimeDbContextFactory<TicketContext> implement eder
    public class TicketContextFactory : IDesignTimeDbContextFactory<BlazorTicketContext>
    {
        public BlazorTicketContext CreateDbContext(string[] args)
        {
            // Config dosyalarını oku
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Migration çalıştırılan klasör baz alınır
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            // Connection string'i al - doğru key'i kullanın
            var connectionString = configuration.GetConnectionString("BlazorSozlukDbConnectionStrings");

            // Eğer yukarıdaki null dönerse, direkt configuration["..."] kullanın
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = configuration["BlazorSozlukDbConnectionStrings"];
            }

            // DbContextOptions oluştur - TicketContext için
            var optionsBuilder = new DbContextOptionsBuilder<BlazorTicketContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // TicketContext'i döndür
            return new BlazorTicketContext(optionsBuilder.Options);
        }
    }
}

