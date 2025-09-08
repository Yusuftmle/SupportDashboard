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
    public class TicketContextFactory:IDesignTimeDbContextFactory<TicketContextFactory>
    {
        public TicketContextFactory CreateDbContext(string[] args)
        {

            // Config dosyalarını oku
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Önemli: migration çalıştırdığın klasör baz alınıyor
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            // Connection string'i al
            var connectionString = configuration["BlazorSozlukDbConnectionStrings"];

            // DbContextOptions oluştur
            var optionsBuilder = new DbContextOptionsBuilder<TicketContextFactory>();
            optionsBuilder.UseSqlServer(connectionString);

            // Context'i döndür
            return new TicketContextFactory(optionsBuilder.Options);

        }

    }
}
