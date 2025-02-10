using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DevIO.Data.Context
{
    public class MeuDbContextFactory : IDesignTimeDbContextFactory<MeuDbContext>
    {
        public MeuDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeuDbContext>();

            // Carrega as configurações do projeto API
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") // Use o mesmo arquivo que está no projeto API
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new MeuDbContext(optionsBuilder.Options);
        }
    }
}
